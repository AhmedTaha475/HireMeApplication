

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

        //[HttpPost]
        //public async Task<ActionResult> CreateProjectPost(CreateProjectPostDto createProjectPostDto)
        //{
        //    Client user = (Client)await _userManager.GetUserAsync(User);
        //    _projectPostManager.CreateProjectPost(createProjectPostDto,user.Id);
        //    return Ok();
        //}
        //[HttpPost]
        //[Route("{id}")]
        //public async Task<ActionResult> UpdateProjectPost(int projectPostId,UpdateProjectPostDto updateProjectPostDto)
        //{
        //    Client user = (Client)await _userManager.GetUserAsync(User);
        //    _projectPostManager.UpdateProjectPost(projectPostId,updateProjectPostDto, user.Id);
        //    return Ok();
        //}
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteProjectPost(int projectPostId)
        {
            try
            {
                _projectPostManager.DeleteProjectPost(projectPostId);
                return NoContent();

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

