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

        public async Task<Token> Login(string Email, String Password)
        {
            var adminEmail = _configuration["AdminCred:adminEmail"];
            var adminPasswrod = _configuration["AdminCred:adminPassword"];

            if(Email==adminEmail &&  Password==adminPasswrod)
            {
                return await ReturnWithAdminAccount(Email, Password);   
            }


            var user = (SystemUser)await usermanager.FindByEmailAsync(Email);
            if (user == null)
                return null;
            

            var isAuthenticated = await usermanager.CheckPasswordAsync(user, Password);
            if (!isAuthenticated)
            {
                return null;
            }

            return await CreateToken(user);
        }


        private async Task<Token> ReturnWithAdminAccount(string adminEmail,string adminPassword)
        {

            var AdminResult = (SystemUser)await usermanager.FindByEmailAsync(adminEmail);
            if(AdminResult!=null) 
            {
                var PasswordResult=await usermanager.CheckPasswordAsync(AdminResult,adminPassword);

                if (PasswordResult)
                    return await CreateToken(AdminResult);
                else
                    return null;
            }
            else
            {
                SystemUser admin = new SystemUser()
                {
                    FirstName = "HireMe",
                    LastName = "Admin",
                    UserName = "SystemAdmin",
                    Email = adminEmail,
                };
                var CreateResult  = await usermanager.CreateAsync(admin, adminPassword);
                if(CreateResult.Succeeded)
                {
                    var AdminAccount =(SystemUser)await usermanager.FindByEmailAsync(adminEmail);
                    //add admin to admin Role
                    var findAdminRole = await roleManager.RoleExistsAsync("Admin");
                    if(findAdminRole)
                    {
                        await usermanager.AddToRoleAsync(AdminAccount, "Admin");
                        return await CreateToken(AdminAccount);

                    }
                    await roleManager.CreateAsync(new IdentityRole() { Id =Guid.NewGuid().ToString(), Name = "Admin" });
                    await usermanager.AddToRoleAsync(AdminAccount, "Admin");
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,AdminAccount.Id),
                        new Claim(ClaimTypes.Role,"Admin"),
                    };
                    await usermanager.AddClaimsAsync(AdminAccount, claims);
                    return await CreateToken(AdminAccount);
                }
                return null;
            }
        }

        private async Task<Token> CreateToken(SystemUser user)
        {

            var claimsList = await usermanager.GetClaimsAsync(user);

           
            IList<string> FetchUserRoles = await usermanager.GetRolesAsync(user);

            List<string> userRoles = new List<string>(FetchUserRoles);


            for (int i = 0 ; i < userRoles.Count; i++)
            {

                if (!claimsList.Any(a => a.Type == ClaimTypes.Role && a.Value == userRoles[i]))
                {
                    await usermanager.AddClaimAsync(user, new Claim(ClaimTypes.Role, userRoles[i]));
                }
            }

            var UpdatedClaimList = await usermanager.GetClaimsAsync(user);
            var secretKeyString = _configuration.GetSection("SecretKey").ToString();
            var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
            var secretKey = new SymmetricSecurityKey(secretKeyInBytes);

            //Combination SecretKey, HashingAlgorithm
            var siginingCreedentials = new SigningCredentials(secretKey,
                SecurityAlgorithms.HmacSha256Signature);

            var expiry = DateTime.Now.AddDays(4);

            var token = new JwtSecurityToken(
                claims: UpdatedClaimList,
                expires: expiry,
                signingCredentials: siginingCreedentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            return new Token() { token = tokenString, Expiry = expiry, Roles = userRoles };
        }

    }
}






