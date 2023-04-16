using HireMeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public class ClientManager : IClientManager
    {
        private readonly IClientRepo _clientRepo;
        private readonly ISystemUserRepo _systemUserRepo;

        public ClientManager(IClientRepo clientRepo,ISystemUserRepo systemUserRepo)
        {
            this._clientRepo = clientRepo;
            this._systemUserRepo = systemUserRepo;
        }
        public async Task<bool> CreateClient(ReigsterClientDto clientData)
        {

            Client client = new Client() 
            {
                FirstName = clientData.FirstName,
                LastName=clientData.Lastname,
                Email = clientData.Email,
                UserName = clientData.UserName,
            };
          var CreateResult= await _clientRepo.CreateClient(client, clientData.Password);

            if(CreateResult)
                return true;
            else return false;


        }

        public async Task<TokenDto> Login(LoginDto loginCred)
        {
            var token= await _systemUserRepo.Login(loginCred.Email, loginCred.Password);

            if (token!=null)
            {
            return new TokenDto() { Token = token.token, ExpiryDate = token.Expiry, Roles = token.Roles };

            }else return new TokenDto();
        }
    }
}
