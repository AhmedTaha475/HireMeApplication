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
        [HttpDelete]
        public ActionResult DeleteProject(int id)
        {
            try
            {
               if(! projectsManager.DeleteProject(id))
                    return NotFound();
               else return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("Project")]
        public ActionResult<ProjectDetailsReadDto> GetById(int P_Id)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("Projects")]
        public ActionResult<List<ProjectDetailsReadDto>> GetByPortfolioId(int Pf_Id)
        {
            return projectsManager.GetAllProjectsByPortfolioId(Pf_Id);
        }
    }
}
