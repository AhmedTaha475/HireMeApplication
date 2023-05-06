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
            
            return projectsRepo.Add(new Project() {
                Description = projectDto.Description,
                ProjectTitle = projectDto.Title,
                ProjectDate = projectDto.Date,
                MoneyEarned = projectDto.MoneyEarned,
                SystemProject = projectDto.SystemProject,
                PortfolioId = projectDto.portfolioId,
                ProjectImages = projectDto.projectImgs?.Select(c => new ProjectImage() { Image = Helper.ConvertFromFileToByteArray(c) }).ToHashSet()?? new HashSet<ProjectImage>()
            });
           
        }

        public bool DeleteProject(int id)
        {
            return projectsRepo.Delete(id);
                
        }

        public List<ProjectDetailsReadDto> getAll()
        {
            var projectlist = projectsRepo.GetAll();
            if(projectlist !=null)
            {
                return projectlist.Select(p => new ProjectDetailsReadDto()
                {
                    P_Id = p.ProjectID,
                    Date = p.ProjectDate,
                    Description = p.Description,
                    MoneyEarned = p.MoneyEarned,
                    SystemProject = p.SystemProject,
                    Title = p.ProjectTitle,
                }).ToList();
            }return null;
        
        }

        public List<ProjectDetailsReadDto> GetAllProjectsByPortfolioId(int PortFolio_Id)
        {
            List<Project>? projects = projectsRepo.GetAllByPortfolioId(PortFolio_Id);
            if (projects != null)
            {
                return projects.Select(p => new ProjectDetailsReadDto()
                {
                    P_Id = p.ProjectID,
                    Description = p.Description,
                    Title = p.ProjectTitle,
                    Date = p.ProjectDate,
                    SystemProject = p.SystemProject,
                    MoneyEarned = p.MoneyEarned,
                }).ToList();
            }return null;
            
        }

        public ProjectDetailsReadDto GetById(int id)
        {
            Project p = projectsRepo.GetById(id);
            if (p != null)
                return new ProjectDetailsReadDto()
                {
                    P_Id = p.ProjectID,
                    Description = p.Description,
                    Title = p.ProjectTitle,
                    Date = p.ProjectDate,
                    SystemProject = p.SystemProject,
                    MoneyEarned = p.MoneyEarned,
                   
                };
            return null;
        }

        public bool UpdateByProjectId(UpdateProjectByIdDto updateProjectByIdDto,int id)
        {
            var project = new Project()
            {
                ProjectID=updateProjectByIdDto.ProjectID,
                Description=updateProjectByIdDto.Description,
                ProjectDate = updateProjectByIdDto.ProjectDate,
                ProjectTitle = updateProjectByIdDto.ProjectTitle,
                SystemProject=updateProjectByIdDto.SystemProject,
                MoneyEarned=updateProjectByIdDto.MoneyEarned,
                
            };
            return projectsRepo.Update(project, id);
                
        }
    }
}
