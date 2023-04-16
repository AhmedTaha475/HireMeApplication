using HireMeBLL.Dtos;
using HireMeDAL.Data.Models;
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
    }
}
