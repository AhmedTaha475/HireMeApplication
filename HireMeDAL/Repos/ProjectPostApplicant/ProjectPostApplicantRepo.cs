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
        public bool CreateProjectPostApplicant(ProjectPostApplicant projectPostApplicant)
        {
            try
            {
                _hireMeContext.projectPostApplicants.Add(projectPostApplicant);
                SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
          
        }

        public bool DeleteProjectPostApplicant(string id)
        {
            var projectPostApplicant = _hireMeContext.projectPostApplicants.FirstOrDefault(ppa=>ppa.FreelancerId == id);
            if (projectPostApplicant != null)
            {
                _hireMeContext.projectPostApplicants.Remove(projectPostApplicant);
                SaveChanges();
                return true;
            }return false;
        }

        public List<ProjectPostApplicant> GetProjectPostApplicants(int projectPostId)
        {
            return _hireMeContext.projectPostApplicants.Where(ppa=>ppa.PP_ID== projectPostId).ToList();
        }

        public List<ProjectPostApplicant> GetProjectPostApplicantById(string id)
        {
            return _hireMeContext.projectPostApplicants.Where(ppa => ppa.FreelancerId == id).ToList();
        }
        public int SaveChanges()
        {
            return _hireMeContext.SaveChanges();
        }

        public bool UpdateProjectPostApplicant(int id, ProjectPostApplicant projectPostApplicant)
        {
            

            var currentApplication = _hireMeContext.projectPostApplicants
                .FirstOrDefault(p => p.PP_ID == id && p.FreelancerId == projectPostApplicant.FreelancerId);
            if (currentApplication != null)
            {
                currentApplication.BiddingPrice = projectPostApplicant.BiddingPrice;
                currentApplication.Proposal=projectPostApplicant.Proposal;
                currentApplication.Approved=projectPostApplicant.Approved;
                SaveChanges();
                return true;
            }return false;


        }

        public List<ProjectPostApplicant> GetAll()
        {
            return _hireMeContext.projectPostApplicants.ToList();
        }
    }
}
