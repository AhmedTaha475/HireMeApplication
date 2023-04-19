using HireMeBLL;
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
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (!projectCommentManager.PostComment(commentDto))
                    return BadRequest(new {message="Somethign went wrong..."});
                return Ok(new {message="Comment added successfully"});
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            try{
                if (!projectCommentManager.DeleteComment(id))
                    return NotFound(new {message="Comment not found"});
                else
                return NoContent();
            }catch(Exception ex) 
            { return BadRequest(ex.Message); }
        }
        [HttpPut]
        public ActionResult UpdateComment(UpdateCommentDto updateCommentDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            try
            {
                if (projectCommentManager.UpdateComment(updateCommentDto))
                return Ok(new {message="comment updated successfully"});
                else return BadRequest(new { message = "comment not found" });
            }catch(Exception ex) { return BadRequest(ex.Message); }
           
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<List<ProjectCommentReadDto>> GetAllCommentsForProject(int id)
        {
             var list= projectCommentManager.GetAllCommentsWithClientByProjectId(id);
            if (list == null)
                return NotFound(new { message = "No comments found" });
            return Ok(list);
        }
    }
}
