﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL.Repos
{
    public interface IClientRepo
    {
        public List<Client> GetAllClient();
        public Task<Client> GetClientById(string id);
        public Task<int> CreateClient(Client suser);
        public bool UpdateClient(Client user);
        Task<bool> DeleteClient(int id);

    }
}
