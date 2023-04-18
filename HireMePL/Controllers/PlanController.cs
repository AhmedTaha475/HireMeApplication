using HireMeBLL;
using HireMeDAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using System.Numerics;

namespace HireMePL
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IPlanManager _planManager; 
        public PlanController(IPlanManager planManager)
        {
            _planManager = planManager; 
        }
        [HttpGet]
        public ActionResult<List<PlanReadDto>> GetAll() 
        {
            var list = _planManager.GetAll();
            if(list != null) 
            {
            return Ok(list);   
            }else { return NotFound(new { Message = "No plans were found" }); };

        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<PlanReadDto> GetById(int id)
        {
            PlanReadDto? plan = _planManager.GetById(id);
            if(plan is null) 
            {
                return NotFound(new {message=" No plan with this id"});
            }
            return plan; 
        }
        [HttpPost]
        public ActionResult AddPlan(CreatePlanDto plan)
        {
            try
            {
                var result = _planManager.AddPlan(plan);
                if (result)
                {
                    return Ok(new { message = "Plan created successfully" });
                }
                return BadRequest(new { message = "Something went wrong" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
          
        }
        [HttpPut]
        public ActionResult UpdatePlan(int id, PlanReadDto plan)
        {
            try
            {
                if (id != plan.id)
                {
                    return BadRequest();
                }
                if (_planManager.UpdatePlan(plan))
                    return Ok(new { message = "Plan updated....." });
                return BadRequest(new { message = "Something Went wrong........" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }
        [HttpDelete]
        public ActionResult DeletePlan(int id)
        {
            try
            {
                PlanReadDto? plan = _planManager.GetById(id);

                if (plan is null)
                {
                    return NotFound();
                }
                if (_planManager.DeleteById(id))
                    return Ok(new { message = "Plan deleted successfully" });
                return BadRequest(new { messagea = "Something went wrong" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
         
        }
    }
}
