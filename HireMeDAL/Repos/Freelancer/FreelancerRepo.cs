using FluentNHibernate.Conventions.Inspections;
using HireMeDAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class FreelancerRepo : IFreelancerRepo
    {
        private readonly HireMeContext context;
        private readonly IConfiguration configuration;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserManager<IdentityUser> Usermanager { get; }

        public FreelancerRepo(HireMeContext context,UserManager<IdentityUser>usermanager, IConfiguration configuration, RoleManager<IdentityRole> RoleManager )
        {
            this.context = context;
            Usermanager = usermanager;
            this.configuration = configuration;
            roleManager = RoleManager;
        }
        public async Task<bool> CreateFreelancer(Freelancer suser,string password)
        {

            var CheckForEmail = await Usermanager.FindByEmailAsync(suser.Email);
            var CheckForUserName = await Usermanager.FindByNameAsync(suser.UserName);
            if (CheckForEmail != null || CheckForUserName != null)
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
            var Role = roleManager.Roles.FirstOrDefault(r => r.Name == "Freelancer");
            if (Role == null)
            {
                await roleManager.CreateAsync(new IdentityRole() { Name = "Freelancer", Id = Guid.NewGuid().ToString() });
            }
            var addedUser = await Usermanager.FindByEmailAsync(suser.Email);
            await Usermanager.AddToRoleAsync(addedUser, "Freelancer");
            //3-make cliame for user
            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, suser.Id),
                new Claim (ClaimTypes.Role,"Freelancer")

            };
            //4-attach this claim for tis user
            await Usermanager.AddClaimsAsync(addedUser, Claims);
            context.portfolios.Add(new Portfolio() { FreelancerId = addedUser.Id });
            return true;
        }

        public List<Freelancer> GetAllFreelancer()
        {
            return context.freelancers.ToList();
        }

        public async Task<Freelancer> GetFreelancerById(string id)
        {
            return (Freelancer)await Usermanager.FindByIdAsync(id);
        }


        public async Task<bool> UpdateFreelancer(Freelancer user)
        {
            try
            {
                //context.Entry(user).State = EntityState.Modified;
                //context.SaveChanges();
                var updateFreelancer = (Freelancer)await Usermanager.FindByIdAsync(user.Id);
                if (updateFreelancer != null)
                {
                    updateFreelancer.Id = user.Id;
                    updateFreelancer.FirstName = user.FirstName;
                    updateFreelancer.LastName = user.LastName;
                    updateFreelancer.Country = user.Country;
                    updateFreelancer.City = user.City;
                    updateFreelancer.Street = user.Street;

                    updateFreelancer.Age = user.Age;
                    updateFreelancer.SSN = user.SSN;
                    updateFreelancer.Balance = user.Balance;
                    updateFreelancer.PaymentMethodId = user.PaymentMethodId;
                    updateFreelancer.PlanId = user.PlanId;
                    updateFreelancer.CategoryId = user.CategoryId;
                    updateFreelancer.Email = user.Email;
                    updateFreelancer.UserName = user.UserName;
                    updateFreelancer.Rank= user.Rank;
                    updateFreelancer.JobTitle = user.JobTitle;
                    updateFreelancer.Bids = user.Bids;
                    updateFreelancer.Description = user.Description;
                    updateFreelancer.TotalMoneyEarned= user.TotalMoneyEarned;
                    
                    updateFreelancer.AverageRate = user.AverageRate;
                    updateFreelancer.PhoneNumber = user.PhoneNumber;
                    if(user.Image != null)
                        updateFreelancer.Image = user.Image;
                    if(user.CV != null)
                        updateFreelancer.CV = user.CV;
                }
                var result = await Usermanager.UpdateAsync(updateFreelancer);
               return  result.Succeeded;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteFreelancer(string id)
        {
            var deletedUser = await Usermanager.FindByIdAsync(id);
            if (deletedUser != null)
            {
                var deleteresult = await Usermanager.DeleteAsync(deletedUser);
                return deleteresult.Succeeded;
            }
            return false;
        }

        public List<Freelancer> GetAllFreeLancersByCategoryId(int categoryId)
        {
          var list =  context.freelancers.Where(f=>f.CategoryId == categoryId).ToList();
            return list;
        }

    }
}
