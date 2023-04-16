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
    public class ClientRepo : IClientRepo
    {
        private readonly HireMeContext context;
        private readonly IConfiguration configuration;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> Usermanager;

        public ClientRepo(HireMeContext context, UserManager<IdentityUser> usermanager, IConfiguration configuration, RoleManager<IdentityRole> RoleManager)
        {
            this.context = context;
            Usermanager = usermanager;
            this.configuration = configuration;
            roleManager = RoleManager;
        }

        #region Old
        //private readonly HireMeContext context;
        //private readonly UserManager<IdentityUser> usermanager;

        //public SystemUserRepo(HireMeContext context, UserManager<IdentityUser> usermanager)
        //{
        //    this.context = context;
        //    this.usermanager = usermanager;
        //}


        //public int CreateSystemUser(SystemUser suser)
        //{

        //    context.systemUsers.Add(suser);
        //    return context.SaveChanges();
        //}

        //public int DeleteSystemUser(int id)
        //{
        //    var deleteduser = context.systemUsers.Find(id);
        //    if (deleteduser != null)
        //    {
        //        context.systemUsers.Remove(deleteduser);
        //        return context.SaveChanges();

        //    }
        //    return 0;


        //}


        //public List<SystemUser> GetAllSystemUsers()
        //{
        //    return context.systemUsers.ToList();
        //}

        //public SystemUser GetSystemUserById(int id)
        //{
        //    return context.systemUsers.Find(id);
        //}


        //public bool UpdateUserAsync(SystemUser user)
        //{
        //    try
        //    {
        //        context.Entry(user).State = EntityState.Modified;
        //        context.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }


        //} 
        #endregion
        public async Task<bool> CreateClient(Client suser,string password)
        {
            //2-Hash Pasword and create user
            var hashpassword = await Usermanager.CreateAsync(suser, password);
            if (!hashpassword.Succeeded)
            {
                return false;
            }

            //2.5-Roles
            var Role = roleManager.Roles.FirstOrDefault(r => r.Name == "Client");
            if (Role == null)
            {
                await roleManager.CreateAsync(new IdentityRole() { Name = "Client", Id =Guid.NewGuid().ToString()});
            }
            var addedUser = await Usermanager.FindByEmailAsync(suser.Email);
            await Usermanager.AddToRoleAsync(addedUser, "Client");

            //3-make cliame for user
            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, addedUser.Id),
                new Claim (ClaimTypes.Role,"Client")

            };

            //4-attach this claim for tis user
            await Usermanager.AddClaimsAsync(addedUser, Claims);
            return true;
        }

        public async Task<bool> DeleteClient(int id)
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

        public List<Client> GetAllClient()
        {
            return context.clients.ToList();
        }

        public async Task<Client> GetClientById(string id)
        {
            return (Client)await Usermanager.FindByIdAsync(id);
        }

        public bool UpdateClient(Client user)
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
    }
}
