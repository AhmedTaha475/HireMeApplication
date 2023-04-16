using FluentNHibernate.Conventions.Inspections;
using HireMeDAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class FreelancerRepo : IFreelancerRepo
    {
        private readonly HireMeContext context;
        private readonly IConfiguration configuration;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserManager<IdentityUser> Usermanager { get; }

        public FreelancerRepo(HireMeContext context,UserManager<IdentityUser>usermanager, IConfiguration configuration, RoleManager<IdentityRole> RoleManager )
        {
            this.context = context;
            Usermanager = usermanager;
            this.configuration = configuration;
            roleManager = RoleManager;
        }
        public async Task<bool> CreateFrelancer(Freelancer suser,string password)
        {
            //2-Hash Pasword and create user
            var hashpassword = await Usermanager.CreateAsync(suser, password);
            if (!hashpassword.Succeeded)
            {
                return false;
            }

            //2.5-Roles
            var Role = roleManager.Roles.FirstOrDefault(r => r.Name == "Freelancer");
            if (Role == null)
            {
                await roleManager.CreateAsync(new IdentityRole() { Name = "Freelancer", Id = "rrrkfkebhjsehsb" });
            }
            var addedUser = await Usermanager.FindByEmailAsync(suser.Email);
            await Usermanager.AddToRoleAsync(addedUser, "Freelancer");
            //3-make cliame for user
            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, suser.Id),
                new Claim (ClaimTypes.Role,"Freelancer")

            };
            //4-attach this claim for tis user
            await Usermanager.AddClaimsAsync(suser, Claims);
            return true;
        }


        //public async Task<Token> Login(string UserName, String Password)
        //{
        //    var user = await Usermanager.FindByNameAsync(UserName);
        //    if (user == null)
        //    {
        //        return null;
        //    }

        //    var isAuthenitcated = await Usermanager.CheckPasswordAsync(user, Password);
        //    if (!isAuthenitcated)
        //    {
        //        return null;
        //    }

        //    var claimsList = await Usermanager.GetClaimsAsync(user);

        //    var secretKeyString = configuration.GetSection("SecretKey").ToString();
        //    var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
        //    var secretKey = new SymmetricSecurityKey(secretKeyInBytes);

        //    //Combination SecretKey, HashingAlgorithm
        //    var siginingCreedentials = new SigningCredentials(secretKey,
        //        SecurityAlgorithms.HmacSha256Signature);

        //    var expiry = DateTime.Now.AddDays(1);

        //    var token = new JwtSecurityToken(
        //        claims: claimsList,
        //        expires: expiry,
        //        signingCredentials: siginingCreedentials);

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var tokenString = tokenHandler.WriteToken(token);

        //    return new Token() { token = tokenString, Expiry = expiry, Role = "Freelancer" };

        //}
        public List<Freelancer> GetAllFrelancer()
        {
            return context.freelancers.ToList();
        }

        public async Task<Freelancer> GetFrelancerById(string id)
        {
            return (Freelancer)await Usermanager.FindByIdAsync(id);
        }


        public bool UpdateFrelancer(Freelancer user)
        {
            try
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteFrelancer(int id)
        {
            var deleteduser = context.systemUsers.Find(id);
            if (deleteduser != null)
            {
                var deleteresult = await Usermanager.DeleteAsync(deleteduser);
                if (deleteresult.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
