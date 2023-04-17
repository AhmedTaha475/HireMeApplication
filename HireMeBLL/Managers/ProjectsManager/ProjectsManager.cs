using HireMeBLL.Dtos;
using HireMeBLL.Dtos.Project;
using HireMeDAL;
using HireMeDAL.Repos.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL.Managers.ProjectsManager
{
    public class ProjectsManager : IProjectsManager
    {
        private readonly IProjectsRepo projectsRepo;

        public ProjectsManager(IProjectsRepo projectsRepo)
        {
            this.projectsRepo = projectsRepo;
        }
        public bool CreateProject(CreateProjectDto projectDto)
        {
            
               if( projectsRepo.Add(new Project() {
                Description = projectDto.Description ,
                ProjectTitle= projectDto.Title ,
                ProjectDate= projectDto.Date ,
                MoneyEarned= projectDto.MoneyEarned ,
                SystemProject= projectDto.SystemProject ,
                ProjectImages = projectDto.projectImgs.Select(s=>new ProjectImage() {Image=s.Image }).ToHashSet<ProjectImage>()
                }))
                    return true;
               else return false;
           
        }

        public bool DeleteProject(int id)
        {
            return projectsRepo.Delete(id);             
        }

        public List<ProjectDetailsReadDto> GetAllProjectsByPortfolioId(int PortFolio_Id)
        {
            List<Project>? projects = projectsRepo.GetAllByPortfolioId(PortFolio_Id);
            return projects.Select(p => new ProjectDetailsReadDto()
            {
                P_Id = p.ProjectID,
                Description = p.Description,
                Title = p.ProjectTitle,
                Date = p.ProjectDate,
                SystemProject = p.SystemProject,
                MoneyEarned = p.MoneyEarned,
                ProjectReview =
               new PojectReviewReadDto()
               {
                   PR_Id = p.PR_Id,
                   ClientReview = p.ProjectReview.ClientReview,
                   FreelancerReview = p.ProjectReview.FreelancerReview,
                   ClientStars = p.ProjectReview.ClientStars,
                   FreelancerStars = p.ProjectReview.FreelancerStars,
                   Client = new UserChildReadDto()
                   {
                       FName = p.Client.FirstName,
                       LName = p.Client.LastName,
                       Id = p.Client.Id,
                       img = p.Client.Image
                   }
               },
                ProjectComments = p.ProjectComments.Select(c=>new ProjectCommentReadDto(c.Comment, new UserChildReadDto()
                {
                    FName = c.Client.FirstName,
                    LName = c.Client.LastName,
                    Id = c.Client.Id,
                    img = c.Client.Image
                })).ToList(),
                projectImgs = p.ProjectImages.Select(i=> new ProjectImgDto()
                {
                    Image = i.Image,
                }).ToList()
            }).ToList();
        }

        public bool UpdateByProjectId(UpdateProjectByIdDto updateProjectByIdDto)
        {
            throw new NotImplementedException();
        }
    }
}
