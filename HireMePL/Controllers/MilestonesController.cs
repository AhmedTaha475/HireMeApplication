using HireMeBLL;
using HireMeBLL.Dtos.Milestone;
using Microsoft.AspNetCore.Authorization;
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
        [Route("ProjectMileStones/{id}")]
        [Authorize]
        public ActionResult<List<MilestoneDetailsDto>> GetProjectPostsMilestones(int id) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var milestones = _milestoneManager.GetProjectPostMilestones(id);
            if (milestones.Count>0)
                return Ok(milestones);
             return NotFound(new {Message="Can't Find Any Milestones"});
        }
        [HttpGet]
        [Route("Milestone/{id}")]
        [Authorize]
        public ActionResult<MilestoneDetailsDto> GetMilestoneById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var milestones = _milestoneManager.GetMilestoneById(id);
            if (milestones == null)
                return NotFound(new { Message = "Can't Find Milestone" });
            return Ok(milestones);
        }
        [HttpPost]
        [Route("Create")]
        [Authorize(policy:"Client")]
        public ActionResult CreateMilestne(CreateMileStoneDto milestone)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if(_milestoneManager.CreateMilestone(milestone))
                return Ok(new { Message = "Milestone Created Successfully" });
            return BadRequest(new {message="Something went wrong"});
        }
        [HttpPut]
        [Route("Update/{id}")]
        [Authorize(policy:"Client")]
        public ActionResult UpdateMilestne(int id, UpdateMilestoneDto milestone)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                if (_milestoneManager.UpdateMilestone(id, milestone))
                    return Ok(new { Message = "Milestone Updated Successfully" });
                return NotFound(new { message = "MileStone Not found" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
          
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        [Authorize(policy:"Client")]
        public ActionResult DeleteMilestne(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                if(_milestoneManager.DeleteMilestone(id))
                    return Ok(new { Message = "Milestone Deleted Successfully" });
                return NotFound(new { message = "Milestone not found" });
            }catch(Exception ex)
            { return BadRequest(ex.Message); }
            
        }
    }
}
