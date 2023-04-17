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
        public void CreateProjectPostApplicant(ProjectPostApplicantDetailsDto projectPostApplicant)
        {
            _projectPostApplicantRepo.CreateProjectPostApplicant(new ProjectPostApplicant()
            {
                BiddingPrice= projectPostApplicant.BiddingPrice,
                Proposal= projectPostApplicant.Proposal,
                PP_ID= projectPostApplicant.PP_ID,
                FreelancerId= projectPostApplicant.FreelancerId,
            });
        }

        public ProjectPostApplicantDetailsDto GetProjectPostApplicantById(string projectPostApplicantId)
        {
            var applicantDB = _projectPostApplicantRepo.GetProjectPostApplicantById(projectPostApplicantId);
            return new ProjectPostApplicantDetailsDto()
            {
                PP_ID = applicantDB.PP_ID,
                Proposal = applicantDB.Proposal,
                BiddingPrice = applicantDB.BiddingPrice,
                FreelancerId = applicantDB.FreelancerId,
            };
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

        public void UpdateProjectPostApplicant(string projectPostApplicantId, UpdateProjectPostApplicantDto projectPostApplicant)
        {
            if (projectPostApplicantId == projectPostApplicant.FreelancerId) 
            {
                var applicantDB= _projectPostApplicantRepo.GetProjectPostApplicantById(projectPostApplicantId);
                applicantDB.Proposal = projectPostApplicant.Proposal;
                applicantDB.BiddingPrice = projectPostApplicant.BiddingPrice;
                _projectPostApplicantRepo.UpdateProjectPostApplicant(projectPostApplicantId,applicantDB);
            }
        }
    }
}
