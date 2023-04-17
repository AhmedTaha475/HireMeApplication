using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public interface IFreelancerRepo
    {
        public List<Freelancer> GetAllFreelancer();
        public Task<Freelancer> GetFreelancerById(string id);
        public Task<bool> CreateFreelancer(Freelancer suser, string password);
        public Task<bool> UpdateFreelancer(Freelancer user);
        Task<bool> DeleteFreelancer(string id);

    }
}
