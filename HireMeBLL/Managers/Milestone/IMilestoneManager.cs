using HireMeBLL.Dtos.Milestone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public interface IMilestoneManager
    {
        MilestoneDetailsDto GetMilestoneById(int milestoneId);
        List<MilestoneDetailsDto> GetProjectPostMilestones(int projectId);
        void CreateMilestone(MilestoneDetailsDto milestone);
        void UpdateMilestone(int milestoneId, UpdateMilestoneDto updatedMilestone);
        void DeleteMilestone(int milestoneId);
    }
}
