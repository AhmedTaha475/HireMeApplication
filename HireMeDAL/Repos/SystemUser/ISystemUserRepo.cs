using HireMeDAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public interface ISystemUserRepo
    {
        public  Task<bool> CreateSystemUser(SystemUser suser, string password);
        public  Task<Token> Login(string UserName, String Password);

        //public List<SystemUser> GetAllSystemUsers();
        //public  Task<SystemUser> GetSystemUserById(string id);
        //public bool UpdateSystemUser(SystemUser user);
        //Task<bool> DeleteSystemUser(int id);


    }
}
