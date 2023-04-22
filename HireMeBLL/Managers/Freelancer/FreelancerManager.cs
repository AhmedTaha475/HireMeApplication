using HireMeDAL;
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

            return CreateResult;
        }

        public async Task<bool> deleteFreelancer(string id)
        {
            return await _freelancerRepo.DeleteFreelancer(id);
        }

        public List<FreelancerDto> GetAllFreelancers()
        {
            return _freelancerRepo.GetAllFreelancer().Select(c => new FreelancerDto(c.Id, c.FirstName, c.LastName, c.UserName,
              c.Country, c.City, c.Street, c.Image, c.Age, c.SSN, c.Balance,
              c.PaymentMethodId, c.PlanId,c.Email,
              c.Rank,c.JobTitle,c.Bids,c.Description,
              c.TotalMoneyEarned,c.CV,c.AverageRate,c.PhoneNumber)).ToList();
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
                   freelancerToBeReturned.PhoneNumber);
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
                PaymentMethodId = freelancerDto.PaymentMethodId,
                CategoryId = freelancerDto.CategoryId,
                Email = freelancerDto.email,
                UserName = freelancerDto.Username,
                JobTitle= freelancerDto.JobTitle,
                Description = freelancerDto.Description,
                CV = Helper.ConvertFromFileToByteArray(freelancerDto.CV),
                AverageRate= freelancerDto.AverageRate,
                PhoneNumber = freelancerDto.PhoneNumber,

            };
            return await _freelancerRepo.UpdateFreelancer(freelancer);

        }

        public async Task<bool> UpdateFreelancerMoney(Freelancer currentFreelancer)
        {
            return await _freelancerRepo.UpdateFreelancer(currentFreelancer);
        }
    }
}
