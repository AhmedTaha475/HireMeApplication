using HireMeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public class ProjectPostApplicantManager : IProjectPostApplicantManager
    {
        private readonly IProjectPostApplicantRepo _projectPostApplicantRepo;

        public ProjectPostApplicantManager(IProjectPostApplicantRepo projectPostApplicantRepo)
        {
            this._projectPostApplicantRepo = projectPostApplicantRepo;
        }
        public bool CreateProjectPostApplicant(ProjectPostApplicantDetailsDto projectPostApplicant)
        {
            return _projectPostApplicantRepo.CreateProjectPostApplicant(new ProjectPostApplicant()
            {
                BiddingPrice = projectPostApplicant.BiddingPrice,
                Proposal = projectPostApplicant.Proposal,
                PP_ID = projectPostApplicant.PP_ID,
                FreelancerId = projectPostApplicant.FreelancerId,
            });
        }

        public List<ProjectPostApplicantDetailsDto> GetProjectPostApplicantById(string projectPostApplicantId)
        {
            var applicantDB = _projectPostApplicantRepo.GetProjectPostApplicantById(projectPostApplicantId);
            return applicantDB.Select(ppa => new ProjectPostApplicantDetailsDto()
            {
                PP_ID = ppa.PP_ID,
                BiddingPrice = ppa.BiddingPrice,
                FreelancerId = ppa.FreelancerId,
                Proposal = ppa.Proposal,
            }).ToList();

        }

        public List<ProjectPostApplicantDetailsDto> GetProjectPostApplicants(int projectPostId)
        {
            return _projectPostApplicantRepo.GetProjectPostApplicants(projectPostId).Select(ppa => new ProjectPostApplicantDetailsDto()
            {
                PP_ID= ppa.PP_ID,
                BiddingPrice=ppa.BiddingPrice,
                FreelancerId= ppa.FreelancerId,
                Proposal= ppa.Proposal,
            }).ToList();
        }

        public bool UpdateProjectPostApplicant(int projectpostId, UpdateProjectPostApplicantDto projectPostApplicant)
        {
            if (projectpostId == projectPostApplicant.PP_Id) 
            {
                ProjectPostApplicant applicantionToBeUpdated = new ProjectPostApplicant()
                {
                    PP_ID = projectpostId,
                    FreelancerId = projectPostApplicant.FreelancerId,
                    BiddingPrice = projectPostApplicant.BiddingPrice,
                    Proposal = projectPostApplicant.Proposal
                };
                return _projectPostApplicantRepo.UpdateProjectPostApplicant(projectpostId, applicantionToBeUpdated);
                


            }return false;
        }
    }
}
