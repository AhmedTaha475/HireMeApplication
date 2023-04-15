 using FluentNHibernate.Conventions.Inspections;
using HireMeDAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NHibernate.Exceptions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class SystemUserRepo : ISystemUserRepo
    {
        private readonly HireMeContext context;
        private readonly UserManager<IdentityUser> usermanager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> roleManager;

        public SystemUserRepo(HireMeContext _context, UserManager<IdentityUser> _usermanager, IConfiguration configuration, RoleManager<IdentityRole> RoleManager)
        {
            this.context = _context;
            this.usermanager = _usermanager;
            _configuration = configuration;
            roleManager = RoleManager;
        }


        public async Task<bool> CreateSystemUser(SystemUser suser, string password)
        {
            //2-Hash Pasword and create user
            var hashpassword = await usermanager.CreateAsync(suser, password);

            if (!hashpassword.Succeeded)
            {
                Console.WriteLine(hashpassword.Errors.ToString());

                return false;
            }
            //2.5-Roles
            var Role = roleManager.Roles.FirstOrDefault(r => r.Name == "Admin");
            if (Role == null)
            {
                await roleManager.CreateAsync(new IdentityRole() { Name = "Admin", Id = "esenfkfkebhjsehsb" });
            }
            var addedUser = await usermanager.FindByEmailAsync(suser.Email);
            await usermanager.AddToRoleAsync(addedUser, "Admin");

            //3-make cliame for user
            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, addedUser.UserName),
                new Claim (ClaimTypes.Role,"Admin")
            };
            //4-attach this claim for tis user
            await usermanager.AddClaimsAsync(addedUser, Claims);
            Console.WriteLine("Done from dal");
            return true;
        }

        //public async Task <bool> DeleteSystemUser(int id)
        //{
        //    var deleteduser = context.systemUsers.Find(id);
        //    if (deleteduser != null)
        //    {
        //          var deleteresult=await usermanager.DeleteAsync(deleteduser);
        //        if(deleteresult.Succeeded)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}


        //public List<SystemUser> GetAllSystemUsers()
        //{
        //    return context.systemUsers.ToList();
        //}

        //public  async  Task <SystemUser> GetSystemUserById(string id)
        //{
        //    return (SystemUser)await usermanager.FindByIdAsync(id);
        //}


        //public bool UpdateSystemUser(SystemUser user)
        //{
        //    try
        //    {
        //        context.Entry(user).State = EntityState.Modified;
        //         context.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }


        //}


        public async Task<Token> Login(string UserName, String Password)
        {
            var user = await usermanager.FindByNameAsync(UserName);
            if (user == null)
            {
            
                return null;
            }

            var isAuthenitcated = await usermanager.CheckPasswordAsync(user, Password);
            if (!isAuthenitcated)
            {
                return null;
            }

            var claimsList = await usermanager.GetClaimsAsync(user);

            var secretKeyString = _configuration.GetSection("SecretKey").ToString();
            var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
            var secretKey = new SymmetricSecurityKey(secretKeyInBytes);

            //Combination SecretKey, HashingAlgorithm
            var siginingCreedentials = new SigningCredentials(secretKey,
                SecurityAlgorithms.HmacSha256Signature);

            var expiry = DateTime.Now.AddDays(1);

            var token = new JwtSecurityToken(
                claims: claimsList,
                expires: expiry,
                signingCredentials: siginingCreedentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            return new Token() { token = tokenString, Expiry = expiry,Role = "Admin" };

        }
    }
}
