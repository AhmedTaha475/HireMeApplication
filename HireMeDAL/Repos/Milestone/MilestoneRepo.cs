using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class MilestoneRepo : IMilestoneRepo
    {
        private readonly HireMeContext _hireMeContext;

        public MilestoneRepo(HireMeContext hireMeContext)
        {
            this._hireMeContext = hireMeContext;
        }
        public void CreateMilestone(Milestone milestone)
        {
            _hireMeContext.milestones.Add(milestone);
            SaveChanges();
        }

        public void DeleteMilestone(int id)
        {
            var milestone = _hireMeContext.milestones.Find(id);
            if (milestone != null)
            {
                _hireMeContext.milestones.Remove(milestone);
                SaveChanges();
            }
        }

        public List<Milestone> GetALl()
        {
            return _hireMeContext.milestones.ToList();
        }

        public Milestone GetMilestoneById(int id)
        {
            return _hireMeContext.milestones.Find(id) ?? null;
        }

        public List<Milestone> GetProjectPostMilestones(int prjectPostId)
        {
            return _hireMeContext.milestones.Where(m=> m.ProjectPostId== prjectPostId).ToList();
        }

        public int SaveChanges()
        {
            return _hireMeContext.SaveChanges();
        }

        public void UpdateMilestone(int id, Milestone milestone)
        {
            var currentMilestone = GetMilestoneById(id);
            if (currentMilestone != null)
            {
                currentMilestone.ProjectPost = milestone.ProjectPost;
                currentMilestone.ProjectPostId = milestone.ProjectPostId;
                currentMilestone.Name = milestone.Name;
                currentMilestone.Value = milestone.Value;
                currentMilestone.Id = milestone.Id;
                SaveChanges();
            }
        }

    }
}
