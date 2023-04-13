using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL.Repos.ProjectsReview
{
    public class ProjectsReviewRepo : IProjectsReviewRepo
    {
        private readonly HireMeContext context;

        public ProjectsReviewRepo(HireMeContext context)
        {
            this.context = context;
        }
        public bool Add(ProjectReview review)
        {
            try
            {
                context.projectReviews.Add(review);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ProjectReview> GetAllByProjectId(int projectId)
        {
            return context.projectReviews.Where(r=>r.PR_Id== projectId).ToList();
        }
    }
}
