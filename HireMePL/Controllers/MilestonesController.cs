using HireMeBLL;
using HireMeBLL.Dtos.Milestone;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMePL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilestonesController : ControllerBase
    {
        private readonly IMilestoneManager _milestoneManager;

        public MilestonesController(IMilestoneManager milestoneManager)
        {
            this._milestoneManager = milestoneManager;
        }
        [HttpGet]
        [Route("ProjectPost/{projectPostId}/Milestones")]
        public ActionResult<List<MilestoneDetailsDto>> GetProjectPostsMilestones(int projectPostId) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var milestones = _milestoneManager.GetProjectPostMilestones(projectPostId);
            if (milestones == null)
                return NotFound(new {Message="Can't Find Any Milestones"});
            return Ok(milestones);
        }
        [HttpGet]
        [Route("Milestone/{milestoneId}")]
        public ActionResult<MilestoneDetailsDto> GetMilestoneById(int milestoneId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var milestones = _milestoneManager.GetMilestoneById(milestoneId);
            if (milestones == null)
                return NotFound(new { Message = "Can't Find Milestone" });
            return Ok(milestones);
        }
        [HttpPost]
        [Route("Milestone/Create")]
        public ActionResult CreateMilestne(MilestoneDetailsDto milestone)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _milestoneManager.CreateMilestone(milestone);
            return Ok(new { Message = "Milestone Created Successfully" });
        }
        [HttpPut]
        [Route("Milestone/{milestoneId}/Update")]
        public ActionResult UpdateMilestne(int milestoneId, UpdateMilestoneDto milestone)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _milestoneManager.UpdateMilestone(milestoneId, milestone);
            return Ok(new { Message = "Milestone Updated Successfully" });
        }
        [HttpDelete]
        [Route("Milestone/{milestoneId}/Delete")]
        public ActionResult DeleteMilestne(int milestoneId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _milestoneManager.DeleteMilestone(milestoneId);
            return Ok(new { Message = "Milestone Deleted Successfully" });
        }
    }
}
