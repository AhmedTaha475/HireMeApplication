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
        public ActionResult CreateProject([FromForm]CreateProjectDto projectDto)
        {
            try
            {
                if (projectsManager.CreateProject(projectDto))
                    return Ok(new { message = "Project created successfully" });

                else return BadRequest(new { message = "Something went wrong" });
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
         
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
        [Route("Project/{id}")]
        public ActionResult<ProjectDetailsReadDto> GetById(int id)
        {
               var projectdetail= projectsManager.GetById(id);
            if (projectdetail != null)
                return Ok(projectdetail);
            return NotFound(new { message = "Project not found" });
        }
        [HttpGet]
        [Route("ProjectByPortfolioId/{id}")]
        public ActionResult<List<ProjectDetailsReadDto>> GetByPortfolioId(int id)
        {
               var projectList= projectsManager.GetAllProjectsByPortfolioId(id);
            if (projectList != null)
                return Ok(projectList);
            return NotFound(new { message = "No project for this portfolio id" });
        }

        [HttpPut]
        [Route("UpdateProjectById/{id}")]
        public ActionResult UpdateProjectByID(UpdateProjectByIdDto updatedProject,int id)
        {
            try
            {
                if (projectsManager.UpdateByProjectId(updatedProject, id))
                    return Ok(new { message = "Project updated successfully" });
                return BadRequest(new { message = "Somethign went wrong....." });
            }catch  (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
