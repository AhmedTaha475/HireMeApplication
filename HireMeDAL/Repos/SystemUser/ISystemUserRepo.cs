using HireMeDAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public interface ISystemUserRepo
    {
 
        public  Task<Token> Login(string Email, String Password);

        Task<bool> ChangePassword(IdentityUser user, string oldpassword, string NewPassword);

    }
}
