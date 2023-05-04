using HireMeBLL.Dtos.Client;
using HireMeBLL.Dtos.Freelancer;
using HireMeDAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public interface IFreelancerManager
    {
        Task<bool> CreateFreelancer(RegisterFreelancerDto clientData);
        Task<bool> deleteFreelancer(string id);
        List<FreelancerDto> GetAllFreelancers();
        Task<FreelancerDto> GetFreelancerById(string id);
        Task<bool> UpdateFreelancer(UpdateFreelancerDto clientDto);
        Task<bool> UpdateFreelancerMoney(Freelancer currentFreelancer);
        public List<FreelancerDto> GetByCatId(int id);
        public FreelancersCountsDto GetCountsByCatIds(CatIdsDto catIds);
    }
}
