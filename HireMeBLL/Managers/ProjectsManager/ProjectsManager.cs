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
    }
}
