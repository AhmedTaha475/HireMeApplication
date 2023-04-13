using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class ProjectPostApplicantRepo : IProjectPostApplicantRepo
    {
        private readonly HireMeContext _hireMeContext;

        public ProjectPostApplicantRepo(HireMeContext hireMeContext)
        {
            this._hireMeContext = hireMeContext;
        }
        public void CreateProjectPostApplicant(ProjectPostApplicant projectPostApplicant)
        {
            _hireMeContext.projectPostApplicants.Add(projectPostApplicant);
            SaveChanges();
        }

        public void DeleteProjectPostApplicant(int id)
        {
            var projectPostApplicant = _hireMeContext.projectPostApplicants.Find(id);
            if (projectPostApplicant != null)
            {
                _hireMeContext.projectPostApplicants.Remove(projectPostApplicant);
                SaveChanges();
            }
        }

        public List<ProjectPostApplicant> GetALl()
        {
            return _hireMeContext.projectPostApplicants.ToList();
        }

        public ProjectPostApplicant GetProjectPostApplicantById(int id)
        {
            return _hireMeContext.projectPostApplicants.Find(id) ?? null;
        }

        public int SaveChanges()
        {
            return _hireMeContext.SaveChanges();
        }

        public void UpdateProjectPostApplicant(int id, ProjectPostApplicant projectPostApplicant)
        {
            var currentprojectPostApplicant = GetProjectPostApplicantById(id);
            if (currentprojectPostApplicant != null)
            {
                currentprojectPostApplicant.BiddingPrice = projectPostApplicant.BiddingPrice;
                currentprojectPostApplicant.ProjectPost = projectPostApplicant.ProjectPost;
                currentprojectPostApplicant.PP_ID = projectPostApplicant.PP_ID;
                currentprojectPostApplicant.FreelancerId = projectPostApplicant.FreelancerId;
                currentprojectPostApplicant.Freelancer = projectPostApplicant.Freelancer;
                currentprojectPostApplicant.Proposal = projectPostApplicant.Proposal;
                SaveChanges();
            }
        }

    }
}
