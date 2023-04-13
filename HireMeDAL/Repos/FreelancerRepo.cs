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
    public class FreelancerRepo : IFreelancerRepo
    {
        private readonly HireMeContext context;
        public UserManager<IdentityUser> Usermanager { get; }

        public FreelancerRepo(HireMeContext context,UserManager<IdentityUser>usermanager )
        {
            this.context = context;
            Usermanager = usermanager;
        }
        public Task<int> CreateFrelancer(Freelancer suser)
        {
            throw new NotImplementedException();
        }

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

    }
}
