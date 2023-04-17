﻿using HireMeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public class FreelancerManager : IFreelancerManager
    {
        private readonly IFreelancerRepo _freelancerRepo;

        public FreelancerManager(IFreelancerRepo freelancerRepo)
        {
            this._freelancerRepo = freelancerRepo;
        }
        public async Task<bool> CreateFreelancer(RegisterFreelancerDto FreelancerData)
        {
            Freelancer Freelancer = new Freelancer()
            {
                FirstName = FreelancerData.FirstName,
                LastName = FreelancerData.Lastname,
                Email = FreelancerData.Email,
                UserName = FreelancerData.UserName,
                Bids=0,
                Rank=1,
                TotalMoneyEarned=0,
                AverageRate=0,
            };
            var CreateResult = await _freelancerRepo.CreateFreelancer(Freelancer, FreelancerData.Password);

            if (CreateResult)
                return true;
            else return false;
        }

        public async Task<bool> deleteFreelancer(string id)
        {
            if (await _freelancerRepo.DeleteFreelancer(id))
                return true;
            else 
                return false;
        }

        public List<FreelancerDto> GetAllFreelancers()
        {
            return _freelancerRepo.GetAllFreelancer().Select(c => new FreelancerDto(c.Id, c.FirstName, c.LastName, c.UserName,
              c.Country, c.City, c.Street, c.Image, c.Age, c.SSN, c.Balance,
              c.PaymentMethodId, c.PlanId,c.Email,
              c.Rank,c.JobTitle,c.Bids,c.Description,
              c.TotalMoneyEarned,c.CV,c.AverageRate,c.PortfolioId)).ToList();
        }

        public async Task<FreelancerDto> GetFreelancerById(string id)
        {
            var freelancerToBeReturned = await _freelancerRepo.GetFreelancerById(id);
            if (freelancerToBeReturned != null)
                return new FreelancerDto(freelancerToBeReturned.Id, freelancerToBeReturned.FirstName,
                    freelancerToBeReturned.LastName, freelancerToBeReturned.UserName,
                    freelancerToBeReturned.Country, freelancerToBeReturned.City, freelancerToBeReturned.Street,
                    freelancerToBeReturned.Image,
                   freelancerToBeReturned.Age, freelancerToBeReturned.SSN,
                   freelancerToBeReturned.Balance, freelancerToBeReturned.PaymentMethodId,
                   freelancerToBeReturned.PlanId, freelancerToBeReturned.Email, freelancerToBeReturned.Rank, 
                   freelancerToBeReturned.JobTitle, freelancerToBeReturned.Bids,
                   freelancerToBeReturned.Description, freelancerToBeReturned.TotalMoneyEarned, 
                   freelancerToBeReturned.CV, freelancerToBeReturned.AverageRate,
                   freelancerToBeReturned.PortfolioId);
            return null;
        }

        public async Task<bool> UpdateFreelancer(UpdateFreelancerDto freelancerDto)
        {
            var freelancer = new Freelancer()
            {
                Id = freelancerDto.Id,
                FirstName = freelancerDto.FirstName,
                LastName = freelancerDto.LastName,
                Country = freelancerDto.Country,
                City = freelancerDto.City,
                Street = freelancerDto.Street,
                Image = Helper.ConvertFromFileToByteArray(freelancerDto.Image),
                Age = freelancerDto.Age,
                SSN = freelancerDto.SSN,
                Balance = freelancerDto.Balance,
                PlanId = freelancerDto.PlanId,
                PaymentMethodId = freelancerDto.PaymentMethodId,
                CategoryId = freelancerDto.CategoryId,
                Email = freelancerDto.email,
                UserName = freelancerDto.Username,
                Rank = freelancerDto.Rank,
                JobTitle= freelancerDto.JobTitle,
                Bids = freelancerDto.Bids,
                Description = freelancerDto.Description,
                TotalMoneyEarned=freelancerDto.TotalMoneyEarned,
                CV = Helper.ConvertFromFileToByteArray(freelancerDto.CV),
                AverageRate= freelancerDto.AverageRate,
                PortfolioId= freelancerDto.PortfolioId,

            };
            if (await _freelancerRepo.UpdateFreelancer(freelancer))
                return true;
            return false;

        }
    }
}