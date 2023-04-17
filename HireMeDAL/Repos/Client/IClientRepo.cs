using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public interface IClientRepo
    {
        public List<Client> GetAllClient();
        public Task<Client> GetClientById(string id);
        public Task<bool> CreateClient(Client suser,string password);
        public Task<bool> UpdateClient(Client user);
        Task<bool> DeleteClient(string id);

    }
}
