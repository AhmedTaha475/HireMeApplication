using HireMeBLL.Dtos;
using HireMeDAL;
using HireMeDAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public class SystemUserManager:ISystemUserManager
    {

        private readonly ISystemUserRepo systemUserRepo;
        private readonly UserManager<IdentityUser> usermanager;

        public SystemUserManager(ISystemUserRepo SystemUserRepo, UserManager<IdentityUser> usermanager)
        {
            systemUserRepo = SystemUserRepo;
            this.usermanager = usermanager;
        }

        public async Task<TokenDto> Login(LoginDto credential)
        {
            var resultToken= await systemUserRepo.Login(credential.Email, credential.Password);
            if(resultToken != null)
            {
                var Token= new TokenDto() { Token=resultToken.token,ExpiryDate=resultToken.Expiry,Roles=resultToken.Roles};
                return Token;
            }
            return null;
        }
    }
}
