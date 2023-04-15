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


        public async Task <bool> CreateSystemUser(SystemUserDto suser)
        {
            SystemUser user = new SystemUser();
            user.FirstName = suser.FirstName;
            user.LastName = suser.LastName;
            user.Email = suser.Email;
            user.UserName = suser.UserName;
            user.PaymentMethodId = suser.PaymentMethodId;
            user.PlanId = suser.PlanId;
            user.Street = suser.Street;
            user.City = suser.City;
            user.Country = suser.Country;
            user.Age = suser.Age;
            user.Image = suser.Image;
            user.PaymentMethodId = suser.PaymentMethodId;
            user.PhoneNumber = suser.PhoneNumber;
            user.Balance = suser.Balance;
            

            var result =await systemUserRepo.CreateSystemUser(user,suser.Password);
            return result;
        }

        public async Task<Token> Login(LoginDto credential)
        {
            var result= await systemUserRepo.Login(credential.UserName, credential.Password);
            if(result!=null)
            {
                return result;
            }
            return null;
        }
    }
}
