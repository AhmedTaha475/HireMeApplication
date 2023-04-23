using Azure;
using FluentNHibernate.Conventions.Inspections;
using HireMeDAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static NHibernate.Engine.Query.CallableParser;

namespace HireMeDAL
{
    public class ClientRepo : IClientRepo
    {
        private readonly HireMeContext context;
        private readonly IConfiguration configuration;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> Usermanager;

        public ClientRepo(HireMeContext context, UserManager<IdentityUser> usermanager, IConfiguration configuration, RoleManager<IdentityRole> RoleManager)
        {
            this.context = context;
            Usermanager = usermanager;
            this.configuration = configuration;
            roleManager = RoleManager;
        }

        #region Old
        //private readonly HireMeContext context;
        //private readonly UserManager<IdentityUser> usermanager;

        //public SystemUserRepo(HireMeContext context, UserManager<IdentityUser> usermanager)
        //{
        //    this.context = context;
        //    this.usermanager = usermanager;
        //}


        //public int CreateSystemUser(SystemUser suser)
        //{

        //    context.systemUsers.Add(suser);
        //    return context.SaveChanges();
        //}

        //public int DeleteSystemUser(int id)
        //{
        //    var deleteduser = context.systemUsers.Find(id);
        //    if (deleteduser != null)
        //    {
        //        context.systemUsers.Remove(deleteduser);
        //        return context.SaveChanges();

        //    }
        //    return 0;


        //}


        //public List<SystemUser> GetAllSystemUsers()
        //{
        //    return context.systemUsers.ToList();
        //}

        //public SystemUser GetSystemUserById(int id)
        //{
        //    return context.systemUsers.Find(id);
        //}


        //public bool UpdateUserAsync(SystemUser user)
        //{
        //    try
        //    {
        //        context.Entry(user).State = EntityState.Modified;
        //        context.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }


        //} 
        #endregion
        public async Task<bool> CreateClient(Client suser,string password)
        {

            var CheckForEmail=await Usermanager.FindByEmailAsync(suser.Email);
            var CheckForUserName=await Usermanager.FindByNameAsync(suser.UserName);
            if(CheckForEmail!=null || CheckForUserName != null) 
            {
                return false;
            }

            //2-Hash Pasword and create user
            var hashpassword = await Usermanager.CreateAsync(suser, password);
            if (!hashpassword.Succeeded)
            {
                return false;
            }

            //2.5-Roles
            var Role = roleManager.Roles.FirstOrDefault(r => r.Name == "Client");
            if (Role == null)
            {
                await roleManager.CreateAsync(new IdentityRole() { Name = "Client", Id =Guid.NewGuid().ToString()});
            }
            var addedUser = await Usermanager.FindByEmailAsync(suser.Email);
            await Usermanager.AddToRoleAsync(addedUser, "Client");

            //3-make cliame for user
            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, addedUser.Id),
                new Claim (ClaimTypes.Role,"Client")

            };

            //4-attach this claim for tis user
            await Usermanager.AddClaimsAsync(addedUser, Claims);
            return true;
        }

        public async Task<bool> DeleteClient(string id)
        {
            //var deleteduser = context.systemUsers.Find(id);
            var deletedUser = await Usermanager.FindByIdAsync(id);
            if (deletedUser !=null)
            {
                var deleteresult = await Usermanager.DeleteAsync(deletedUser);
                return deleteresult.Succeeded;
            }
            return false;
        }

        public List<Client> GetAllClient()
        {
            return context.clients.ToList();
        }

        public async Task<Client> GetClientById(string id)
        {
            return (Client)await Usermanager.FindByIdAsync(id);
        }

        public async Task<bool> UpdateClient(Client clientDto)
        {
            try
            {
                
                var updatedClient = (Client)await Usermanager.FindByIdAsync(clientDto.Id);
                if (updatedClient != null)
                {
                    updatedClient.Id = clientDto.Id;
                    updatedClient.FirstName = clientDto.FirstName;
                    updatedClient.LastName = clientDto.LastName;
                    updatedClient.Country = clientDto.Country;
                    updatedClient.City = clientDto.City;
                    updatedClient.Street = clientDto.Street;
                    updatedClient.Age = clientDto.Age;
                    updatedClient.SSN = clientDto.SSN;
                    updatedClient.Balance = clientDto.Balance;
                    updatedClient.TotalMoneySpent = clientDto.TotalMoneySpent;
                    updatedClient.PaymentMethodId = clientDto.PaymentMethodId;
                    updatedClient.PlanId = clientDto.PlanId;
                    updatedClient.CategoryId = clientDto.CategoryId;
                    updatedClient.Email = clientDto.Email;
                    updatedClient.UserName=clientDto.UserName;
                    updatedClient.PhoneNumber = clientDto.PhoneNumber;
                    if(clientDto.Image != null)
                    {
                        updatedClient.Image = clientDto.Image;
                    }
                }
                var result=  await Usermanager.UpdateAsync(updatedClient);
                return result.Succeeded;
               
            }
            catch
            {
                return false;
            }

        }
    }
}
