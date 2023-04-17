using Microsoft.EntityFrameworkCore;
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

        public List<ProjectReview> GetAllByClientId(string id)
        {
            return context.projectReviews.Include(r => r.Project).Include(r=>r.Freelancer).Where(r => r.Project.ClientId == id).ToList();
        }

        public List<ProjectReview> GetAllByFreeLancerId(string id)
        {
            return context.projectReviews.Include(r=>r.Project).Include(r => r.Client).Where(r => r.FreeLancerId == id).ToList();
        }

        public ProjectReview GetByProjectId(int projectId)
        {
            return context.projectReviews.Include(r=>r.Freelancer).Include(r=>r.Client).FirstOrDefault(r=>r.PR_Id== projectId);
        }

        public bool Update(ProjectReview review, int PR_Id)
        {
            var R = context.projectReviews.Find(PR_Id);
            if (R is null)
                return false;
            if (PR_Id != R.PR_Id)
                return false;
            R.FreelancerReview = review.FreelancerReview;
            R.FreelancerStars = review.FreelancerStars;
            R.FreeLancerId =review.FreeLancerId;
            context.SaveChanges();
            return true;
        }
    }
}
