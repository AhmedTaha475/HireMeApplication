using HireMeBLL.Dtos.Milestone;
using HireMeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public class MilestoneManager : IMilestoneManager
    {
        private readonly IMilestoneRepo _milestoneRepo;

        public MilestoneManager(IMilestoneRepo milestoneRepo)
        {
            this._milestoneRepo = milestoneRepo;
        }

        public void CreateMilestone(MilestoneDetailsDto milestone)
        {
            _milestoneRepo.CreateMilestone(new Milestone() { 
                Id= milestone.Id,
                Name= milestone.Name,
                ProjectPostId= milestone.ProjectPostId,
                Value= milestone.Value,
            });
        }

        public void DeleteMilestone(int milestoneId)
        {
            _milestoneRepo.DeleteMilestone(milestoneId);
        }

        public MilestoneDetailsDto GetMilestoneById(int milestoneId)
        {
            var milestoneDB = _milestoneRepo.GetMilestoneById(milestoneId);
            return new MilestoneDetailsDto() { 
                Id= milestoneDB.Id,
                Name= milestoneDB.Name,
                ProjectPostId= milestoneDB.ProjectPostId, 
                Value= milestoneDB.Value };
        }

        public List<MilestoneDetailsDto> GetProjectPostMilestones(int projectId)
        {
            return _milestoneRepo.GetProjectPostMilestones(projectId).Select(m => new MilestoneDetailsDto()
            {
                Id = m.Id, 
                Name= m.Name,
                Value= m.Value,
                ProjectPostId= m.ProjectPostId
            }).ToList();
        }

        public void UpdateMilestone(int milestoneId, UpdateMilestoneDto updatedMilestone)
        {
            var milestone = _milestoneRepo.GetMilestoneById(milestoneId);
            if (milestone != null)
            {
                milestone.Name = updatedMilestone.Name;
                milestone.Value = updatedMilestone.Value;
                _milestoneRepo.UpdateMilestone(milestoneId, milestone);
            }
        }
    }
}
