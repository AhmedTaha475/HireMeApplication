using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public interface IMilestoneRepo
    {
        List<Milestone> GetALl();
        Milestone GetMilestoneById(int id);

        void CreateMilestone(Milestone milestone);

        void UpdateMilestone(int id, Milestone milestone);

        void DeleteMilestone(int id);
        int SaveChanges();
    }
}
