using HireMeBLL.Dtos.ProjectComment;
using HireMeBLL.Managers.ProjectComment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMePL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectCommentsController : ControllerBase
    {
        private readonly IProjectCommentManager projectCommentManager;

        public ProjectCommentsController(IProjectCommentManager projectCommentManager)
        {
            this.projectCommentManager = projectCommentManager;
        }

        [HttpPost]
        public ActionResult PostComment(CreateProjectCommentDto commentDto)
        {
            if (!projectCommentManager.PostComment(commentDto))
                return BadRequest();
           return Ok();
        }
        [HttpDelete]
        public ActionResult Delete(int Commentid)
        {
            try{
                if (!projectCommentManager.DeleteComment(Commentid))
                    return NotFound();
                else
                return NoContent();
            }catch
            { return BadRequest(); }
        }
        [HttpPut]
        public ActionResult UpdateComment(UpdateCommentDto updateCommentDto)
        {
            try
            {
                if (projectCommentManager.UpdateComment(updateCommentDto))
                return Ok();
                else return BadRequest();
            }catch { return BadRequest(); }
           
        }
        [HttpGet]
        public ActionResult<List<ProjectCommentReadDto>> GetAllCommentsForProject(int ProjectId)
        {
           return projectCommentManager.GetAllCommentsWithClientByProjectId(ProjectId);
        }
    }
}
