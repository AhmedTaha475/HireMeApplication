using HireMeBLL;
using HireMeBLL.Dtos.ProjectPost;
using HireMeDAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HireMePL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(policy: "Client")]
    public class ProjectPostsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IProjectPostManager _projectPostManager;

        public ProjectPostsController(UserManager<IdentityUser> userManager, IProjectPostManager projectPostManager)
        {
            this._userManager = userManager;
            this._projectPostManager = projectPostManager;
        }
        [HttpPost]
        [Route("Create")]
        [Authorize]
        public async Task<ActionResult> CreateProjectPost(CreateProjectPostDto createProjectPostDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Client user = (Client)await _userManager.GetUserAsync(User);
           if(_projectPostManager.CreateProjectPost(createProjectPostDto,user.Id))
                return Ok(new { Message = "Project Post Created Successfully" });
           return BadRequest(new {Message="Somethign went wrong...."});
                
        }
        [HttpPut]
        [Route("Update/{id}")]
        [Authorize]
        public async Task<ActionResult> UpdateProjectPost(int id, UpdateProjectPostDto updateProjectPostDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                Client user = (Client)await _userManager.GetUserAsync(User);
                if(_projectPostManager.UpdateProjectPost(id, updateProjectPostDto, user.Id))
                    return Ok(new { Message = "Project Post Updated Successfully" });
                return BadRequest(new { Message = "Project post not found" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }
        [HttpDelete]
        [Route("Delete/{id}")]

        public async Task<ActionResult> DeleteProjectPost(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                if(_projectPostManager.DeleteProjectPost(id))
                    return Ok(new { Message = "Project Post Deleted Successfully" });
                return BadRequest(new { Message = "Project Post not found" });

            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("ProjectPostWithApplicants/{id}")]
        [AllowAnonymous]
        public ActionResult<ProjectPostWithApplicantsDetailsDto> GetProjectPostWithApplicantsById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var projectPost = _projectPostManager.GetProjectPostWithApplicantsById(id);
            if (projectPost != null)
                return Ok(projectPost);
            return NotFound(new {Message="Can't Find Project Post"});

        }



        [HttpGet]
        [Route("GetAll")]

        public ActionResult<List<ProjectPostDto>> GetAll()
        {
            var PPList = _projectPostManager.GetAll();
            if(PPList != null)
                return Ok(PPList);
            else return BadRequest(new {message="No Project posts found"});
        }

        [HttpGet]
        [Route("GetProjectPostById/{id}")]

        public ActionResult<ProjectPostDto> GetProjectPostById(int id)
        {
            var ProjectPostDto = _projectPostManager.GetProjectPostById(id);
            if(ProjectPostDto != null) return Ok(ProjectPostDto);
            return BadRequest(new { message = "Project post not found" });


        }
    }
}
