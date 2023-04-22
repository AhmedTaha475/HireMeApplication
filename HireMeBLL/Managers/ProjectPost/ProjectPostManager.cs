using HireMeBLL.Dtos.ProjectPost;
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
        public bool CreateProjectPost(CreateProjectPostDto createProjectPostDto, string clientId)
        {
            ProjectPost projectPost = new ProjectPost()
            {
                PostTitle= createProjectPostDto.PostTitle,
                Description= createProjectPostDto.Description,
                AveragePrice= createProjectPostDto.AveragePrice,
                CategoryId= createProjectPostDto.CategoryId,
                ClientId= clientId,
            };
            return _projectPostRepo.CreateProjectPost(projectPost);
        }

        public bool DeleteProjectPost(int projectPostId)
        {
            return _projectPostRepo.DeleteProjectPost(projectPostId);
        }

        public List<ProjectPostDto> GetAll()
        {
           var projectpostList= _projectPostRepo.GetALl();
            if(projectpostList.Count>0)
                return projectpostList.Select(p=>new ProjectPostDto() { Id=p.Pp_Id, PostTitle=p.PostTitle,AveragePrice=p.AveragePrice, CategoryId=p.CategoryId,Description=p.Description}).ToList();
            return null;
        }

        public ProjectPostDto GetProjectPostById(int id)
        {
            var projectpost=_projectPostRepo.GetProjectPostById(id);
            if (projectpost == null)
                return null;
            return new ProjectPostDto() { Id=id, PostTitle=projectpost.PostTitle,AveragePrice = projectpost.AveragePrice,CategoryId=projectpost.CategoryId, Description=projectpost.Description };
        }

        public ProjectPostWithApplicantsDetailsDto GetProjectPostWithApplicantsById(int projectId)
        {
            var projectPostDB = _projectPostRepo.GetProjectPostWithApplicantsById(projectId);
            if(projectPostDB!=null)
            {
                var applicantsDB = projectPostDB.ProjectPostApplicants;
                List<ProjectPostApplicantDetailsDto> applicantsDto = new List<ProjectPostApplicantDetailsDto>();
                foreach (var applicantDB in applicantsDB)
                {
                    applicantsDto.Add(new ProjectPostApplicantDetailsDto()
                    {
                        PP_ID = applicantDB.PP_ID,
                        Proposal = applicantDB.Proposal,
                        BiddingPrice = applicantDB.BiddingPrice,
                        FreelancerId = applicantDB.FreelancerId,
                    });
                }
                return new ProjectPostWithApplicantsDetailsDto()
                {
                    PostTitle = projectPostDB.PostTitle,
                    AveragePrice = projectPostDB.AveragePrice,
                    CategoryId = projectPostDB.CategoryId,
                    Description = projectPostDB.Description,
                    ProjectPostApplicants = applicantsDto,
                    id  = projectId
                };
            }return null;
          
            
           
        }

        public bool UpdateProjectPost(int projectPostId, UpdateProjectPostDto updateProjectPostDto, string clientId)
        {
            var projectPost= _projectPostRepo.GetProjectPostById(projectPostId);
            if (projectPost != null && projectPost.ClientId == clientId)
            {
                projectPost.PostTitle = updateProjectPostDto.PostTitle;
                projectPost.Description = updateProjectPostDto.Description;
                projectPost.AveragePrice = updateProjectPostDto.AveragePrice;
                projectPost.CategoryId = updateProjectPostDto.CategoryId;

                return _projectPostRepo.UpdateProjectPost(projectPostId, projectPost);
            }return false;
        }

      
    }
}
