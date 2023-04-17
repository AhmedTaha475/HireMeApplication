<<<<<<< HEAD
﻿using HireMeBLL;
using HireMeDAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HireMePL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(policy: "Client")]
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
        public async Task<ActionResult> CreateProjectPost(CreateProjectPostDto createProjectPostDto)
        {
            Client user = (Client)await _userManager.GetUserAsync(User);
            _projectPostManager.CreateProjectPost(createProjectPostDto,user.Id);
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> UpdateProjectPost(int projectPostId,UpdateProjectPostDto updateProjectPostDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Client user = (Client)await _userManager.GetUserAsync(User);
            _projectPostManager.UpdateProjectPost(projectPostId,updateProjectPostDto, user.Id);
            return Ok(new {Message="Updated Successfully!"});
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteProjectPost(int projectPostId)
        {
            try
            {
                _projectPostManager.DeleteProjectPost(projectPostId);
                return Ok(new { Message = "Deleted Successfully!" });

            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public ActionResult<ProjectPostWithApplicantsDetailsDto> GetProjectPostWithApplicantsById(int id)
        {

            var projectPost = _projectPostManager.GetProjectPostWithApplicantsById(id);
            if (projectPost != null)
                return Ok(projectPost);
            return NotFound();

        }
    }
}
=======

﻿using HireMeBLL;
using HireMeDAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HireMePL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(policy: "Client")]
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
        [Route("ProjectPost/Create")]

        public async Task<ActionResult> CreateProjectPost(CreateProjectPostDto createProjectPostDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Client user = (Client)await _userManager.GetUserAsync(User);
            _projectPostManager.CreateProjectPost(createProjectPostDto,user.Id);
            return Ok(new { Message = "Project Post Created Successfully" });
        }
        [HttpPut]
        [Route("ProjectPost/{projectPostId}/Update")]
        public async Task<ActionResult> UpdateProjectPost(int projectPostId,UpdateProjectPostDto updateProjectPostDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Client user = (Client)await _userManager.GetUserAsync(User);
            _projectPostManager.UpdateProjectPost(projectPostId,updateProjectPostDto, user.Id);
            return Ok(new { Message = "Project Post Updated Successfully" });
        }
        [HttpDelete]
        [Route("ProjectPost/{projectPostId}/Delete")]

        public async Task<ActionResult> DeleteProjectPost(int projectPostId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _projectPostManager.DeleteProjectPost(projectPostId);
                return Ok(new { Message = "Project Post Deleted Successfully" });

            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("ProjectPost/{id}")]
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
    }
}


>>>>>>> 03878b86e261aa06ff77f735429c89723a8c39f0
