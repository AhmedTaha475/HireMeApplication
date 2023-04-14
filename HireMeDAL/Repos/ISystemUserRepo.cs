using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL.Repos
{
    public interface ISystemUserRepo
    {
        public List<SystemUser> GetAllSystemUsers();
        public  Task<SystemUser> GetSystemUserById(string id);
        public  Task<int> CreateSystemUser(SystemUser suser);
        public bool UpdateSystemUser(SystemUser user);
        Task<bool> DeleteSystemUser(int id);


    }
}
