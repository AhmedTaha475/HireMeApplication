using HireMeBLL.Dtos;
using HireMeBLL.Dtos.Project;
using HireMeBLL.Managers.ProjectsManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMePL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsManager projectsManager;

        public ProjectsController(IProjectsManager projectsManager)
        {
            this.projectsManager = projectsManager;
        }
        [HttpPost]
        public ActionResult CreateProject(CreateProjectDto projectDto)
        {
          if(projectsManager.CreateProject(projectDto))
                return CreatedAtAction(
                actionName: nameof(GetById),
            value: new { Message = "Project has been created successfully." }
                );
          else return BadRequest();
        }
        [HttpGet]
        public ActionResult<ProjectDetailsReadDto> GetById()
        {
            throw new NotImplementedException();
        }
    }
}
