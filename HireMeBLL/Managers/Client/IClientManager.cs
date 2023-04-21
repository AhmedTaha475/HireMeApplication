using HireMeBLL.Dtos.Client;
using HireMeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public interface IClientManager
    {
        Task<bool> CreateClient(ReigsterClientDto clientData);
        Task<bool> deleteClient(string id);
        List<ClientDto> GetAllClients();
        Task<ClientDto> GetClientById( string id);
        Task<TokenDto> Login(LoginDto loginCred);
        Task<bool> UpdateClient( UpdateClientDto clientDto);
        Task<bool> UpdateClientMoney(Client currentClient);
    }
}
