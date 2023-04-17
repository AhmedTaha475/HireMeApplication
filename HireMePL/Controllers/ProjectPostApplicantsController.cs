using HireMeBLL;
using HireMeDAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMePL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectPostApplicantsController : ControllerBase
    {
        private readonly IProjectPostApplicantManager _projectPostApplicantManager;

        public ProjectPostApplicantsController(IProjectPostApplicantManager projectPostApplicantManager)
        {
            this._projectPostApplicantManager = projectPostApplicantManager;
        }
        [HttpGet]
        [Route("ProjectPostApplicant/{projectPostId}")]
        public ActionResult<List<ProjectPostApplicantDetailsDto>> GetProjectPostApplicants(int projectPostId) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                return _projectPostApplicantManager.GetProjectPostApplicants(projectPostId);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("ProjectPostApplicant/{projectPostApplicantId}")]
        public ActionResult<ProjectPostApplicantDetailsDto> GetProjectPostApplicantById(string projectPostApplicantId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                return _projectPostApplicantManager.GetProjectPostApplicantById(projectPostApplicantId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
                
        }
        [HttpPut]
        [Route("ProjectPostApplicant/{projectPostApplicantId}/Update")]
        public ActionResult UpdateProjectPostApplicant(string projectPostApplicantId, UpdateProjectPostApplicantDto projectPostApplicant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _projectPostApplicantManager.UpdateProjectPostApplicant(projectPostApplicantId, projectPostApplicant);
            return Ok(new { Message = "Applicant Updated Successfully" });
            
        }
        [HttpPost]
        [Route("ProjectPostApplicant/Create")]
        public ActionResult CreateProjectPostApplicant(ProjectPostApplicantDetailsDto projectPostApplicant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _projectPostApplicantManager.CreateProjectPostApplicant(projectPostApplicant);
            return Ok(new { Message = "Applicant Created Successfully" });
        }
    }
}
