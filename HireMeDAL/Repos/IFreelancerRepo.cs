using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL.Repos
{
    public interface IFreelancerRepo
    {
        public List<Freelancer> GetAllFrelancer();
        public Task<Freelancer> GetFrelancerById(string id);
        public Task<int> CreateFrelancer(Freelancer suser);
        public bool UpdateFrelancer(Freelancer user);
        Task<bool> DeleteFrelancer(int id);

    }
}
