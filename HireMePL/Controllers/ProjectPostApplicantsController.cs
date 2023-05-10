using HireMeBLL;
using HireMeDAL;
using Microsoft.AspNetCore.Authorization;
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
        [Route("GetAllByProjectPostId/{id}")]
        public ActionResult<List<ProjectPostApplicantDetailsDto>> GetProjectPostApplicants(int id) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var PPA_list = _projectPostApplicantManager.GetProjectPostApplicants(id);
                    if(PPA_list.Count > 0)
                        return Ok(PPA_list);
                return NotFound(new { message = "No project post applicants were found" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetByProjectPostAppId/{id}")]
        
        public ActionResult<List<ProjectPostApplicantDetailsDto>> GetProjectPostApplicantById(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                   var applicants= _projectPostApplicantManager.GetProjectPostApplicantById(id);
                if (applicants.Count>0)
                    return Ok(applicants);
                return NotFound(new { message = "Applicant not found" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
                
        }
        [HttpPut]
        [Route("Update/{id}")]
        [Authorize]
        public ActionResult UpdateProjectPostApplicant(int id, UpdateProjectPostApplicantDto projectPostApplicant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                if(_projectPostApplicantManager.UpdateProjectPostApplicant(id, projectPostApplicant))
                    return Ok(new { Message = "Applicant Updated Successfully" });
                return NotFound(new { message = "Applicant not found" });
                    
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
            
        }
        [HttpPost]
        [Route("ProjectPostApplicant/Create")]
        [Authorize(policy: "Freelancer")]
        public ActionResult CreateProjectPostApplicant(ProjectPostApplicantDetailsDto projectPostApplicant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if(_projectPostApplicantManager.CreateProjectPostApplicant(projectPostApplicant))
                return Ok(new { Message = "Applicant Created Successfully" });
            return BadRequest(new {message="Something went wrong....."});
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<ProjectPostApplicantDetailsDto>>  GetAllApplicants()
        {
            var resultList= this._projectPostApplicantManager.GetAll();
            if (resultList == null)
                return NotFound(new { message = "No Applicants Found" });
            return Ok(resultList);
        }
    }
}
