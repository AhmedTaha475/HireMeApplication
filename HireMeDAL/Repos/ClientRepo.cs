using FluentNHibernate.Conventions.Inspections;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL.Repos
{
    public class ClientRepo : IClientRepo
    {
        private readonly HireMeContext context;
        public UserManager<IdentityUser> Usermanager { get; }

        public ClientRepo(HireMeContext context,UserManager<IdentityUser>usermanager )
        {
            this.context = context;
            Usermanager = usermanager;
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
        public Task<int> CreateClient(Client suser)
        {
            throw new NotImplementedException();
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
