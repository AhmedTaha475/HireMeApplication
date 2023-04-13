using HireMeDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public class ProjectPostManager : IProjectPostManager
    {
        private readonly IProjectPostRepo _projectPostRepo;

        public ProjectPostManager(IProjectPostRepo projectPostRepo)
        {
            this._projectPostRepo = projectPostRepo;
        }
        public void CreateProjectPost(CreateProjectPostDto createProjectPostDto, string clientId)
        {
            ProjectPost projectPost = new ProjectPost()
            {
                PostTitle= createProjectPostDto.PostTitle,
                Description= createProjectPostDto.Description,
                AveragePrice= createProjectPostDto.AveragePrice,
                CategoryId= createProjectPostDto.CategoryId,
                ClientId= clientId,
            };
            _projectPostRepo.CreateProjectPost(projectPost);
        }

        public void DeleteProjectPost(int projectPostId)
        {
            _projectPostRepo.DeleteProjectPost(projectPostId);
        }

        public ProjectPostWithApplicantsDetailsDto GetProjectPostWithApplicantsById(int projectId)
        {
            var projectPostDB= _projectPostRepo.GetProjectPostWithApplicantsById(projectId);
            var applicantsDB = projectPostDB.ProjectPostApplicants;
            List<ProjectPostApplicantDetailsDto> applicantsDto = new List<ProjectPostApplicantDetailsDto>();
            foreach (var applicantDB in applicantsDB)
            {
                applicantsDto.Add(new ProjectPostApplicantDetailsDto()
                {
                    PP_ID= applicantDB.PP_ID,
                    Proposal= applicantDB.Proposal,
                    BiddingPrice= applicantDB.BiddingPrice,
                    FreelancerId= applicantDB.FreelancerId,
                });
            }
            {

            }
            return new ProjectPostWithApplicantsDetailsDto()
            {
                PostTitle = projectPostDB.PostTitle,
                AveragePrice = projectPostDB.AveragePrice,
                CategoryId = projectPostDB.CategoryId,
                Description = projectPostDB.Description,
                ProjectPostApplicants = applicantsDto,
            };
        }

        public void UpdateProjectPost(int projectPostId, UpdateProjectPostDto updateProjectPostDto, string clientId)
        {
            var projectPost= _projectPostRepo.GetProjectPostById(projectPostId);
            if (projectPost != null && projectPost.ClientId == clientId)
            {
                projectPost.PostTitle = updateProjectPostDto.PostTitle;
                projectPost.Description = updateProjectPostDto.Description;
                projectPost.AveragePrice = updateProjectPostDto.AveragePrice;
                projectPost.CategoryId = updateProjectPostDto.CategoryId;

                _projectPostRepo.UpdateProjectPost(projectPostId, projectPost);
            }
        }

    }
}
