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
            return _planManager.GetAll().ToList();   

        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<PlanReadDto> GetById(int id)
        {
            PlanReadDto? plan = _planManager.GetById(id);
            if(plan is null) 
            {
                return NotFound();
            }
            return plan; 
        }
        [HttpPost]
        public ActionResult AddPlan(PlanReadDto plan)
        {
            PlanReadDto? myPlan = _planManager.GetById(plan.id);
            if (myPlan is null)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPut]
        public ActionResult UpdatePlan(int id, PlanReadDto plan)
        {
            if (id!=plan.id)
            {
                return BadRequest(); 
            }
            _planManager.UpdatePlan(plan);
            return NoContent();
        }
        [HttpDelete]
        public ActionResult DeletePlan(int id)
        {
            PlanReadDto? plan = _planManager.GetById(id);

            if (plan is null)
            {
                return NotFound();
            }
            _planManager.DeleteById(id);
            return NoContent();
        }
    }
}
