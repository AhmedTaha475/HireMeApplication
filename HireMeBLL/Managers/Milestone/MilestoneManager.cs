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

        public bool CreateMilestone(CreateMileStoneDto milestone)
        {
           if( _milestoneRepo.CreateMilestone(new Milestone() { 
                Name= milestone.Name,
                ProjectPostId= milestone.ProjectPostId,
                Value= milestone.Value,
            }))return true;
           return false;
        }

        public bool DeleteMilestone(int milestoneId)
        {
            if(_milestoneRepo.DeleteMilestone(milestoneId))
                return true;
            return false;
        }

        public MilestoneDetailsDto GetMilestoneById(int milestoneId)
        {
            var milestoneDB = _milestoneRepo.GetMilestoneById(milestoneId);
            if(milestoneDB !=null)
            {
                return new MilestoneDetailsDto()
                {
                    Id = milestoneDB.Id,
                    Name = milestoneDB.Name,
                    ProjectPostId = milestoneDB.ProjectPostId,
                    Value = milestoneDB.Value
                };
            }return null;
            
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

        public bool UpdateMilestone(int milestoneId, UpdateMilestoneDto updatedMilestone)
        {
            var milestone = _milestoneRepo.GetMilestoneById(milestoneId);
            if (milestone != null)
            {
                milestone.Name = updatedMilestone.Name;
                milestone.Value = updatedMilestone.Value;
                if(_milestoneRepo.UpdateMilestone(milestoneId, milestone))
                    return true;
            }
            return false;
        }
    }
}
