using HireMeBLL.Dtos.Client;
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
    }
}
