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

        Task<TokenDto> Login(LoginDto loginCred);
    }
}
