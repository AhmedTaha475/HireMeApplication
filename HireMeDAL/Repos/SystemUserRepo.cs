using FluentNHibernate.Conventions.Inspections;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL.Repos
{
    public class SystemUserRepo : ISystemUserRepo
    {
        private readonly HireMeContext context;
        private readonly UserManager<IdentityUser> usermanager;

        public SystemUserRepo(HireMeContext _context, UserManager<IdentityUser> _usermanager)
        {
            this.context = _context;
            this.usermanager = _usermanager;
        }


        public async Task <int> CreateSystemUser(SystemUser suser)
        {
            //var hashpassword = await usermanager.CreateAsync(suser, RegReadDtos.Password);
            //if (!hashpassword.Succeeded)
            //{
            //    return BadRequest(hashpassword.Errors);
            //}
            ////3-make cliame for user
            //var Claims = new List<Claim>
            //{
            //    new Claim(ClaimTypes.NameIdentifier, appuser.Id),
            //    new Claim(ClaimTypes.Role,appuser.MyCustomAttr)

            //};
            ////4-attach this claim for tis user
            //await userManager.AddClaimsAsync(appuser, Claims);



            context.systemUsers.Add(suser);
           return context.SaveChanges();
        }

        public async Task <bool> DeleteSystemUser(int id)
        {
            var deleteduser = context.systemUsers.Find(id);
            if (deleteduser != null)
            {
                  var deleteresult=await usermanager.DeleteAsync(deleteduser);
                if(deleteresult.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }


        public List<SystemUser> GetAllSystemUsers()
        {
            return context.systemUsers.ToList();
        }

        public  async  Task <SystemUser> GetSystemUserById(string id)
        {
            return (SystemUser)await usermanager.FindByIdAsync(id);
        }


        public bool UpdateSystemUser(SystemUser user)
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
