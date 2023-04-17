using HireMeBLL.Dtos;
using HireMeDAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public interface ISystemUserManager
    {
        public Task<TokenDto> Login(LoginDto credential);

        public Task<bool> changeUserPassword(IdentityUser user, string oldpassword,string newpassword);
    }
}
