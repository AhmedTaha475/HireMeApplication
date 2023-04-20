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

        bool CreateMilestone(Milestone milestone);

        bool UpdateMilestone(int id, Milestone milestone);
        List<Milestone> GetProjectPostMilestones(int prjectPostId);
        bool DeleteMilestone(int id);

        int SaveChanges();
    }
}
