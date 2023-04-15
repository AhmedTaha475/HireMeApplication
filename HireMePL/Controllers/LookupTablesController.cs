using HireMeBLL;
using HireMeDAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMePL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupTablesController : ControllerBase
    {
        private readonly ILookupTableManager lookupTableManager;

        public LookupTablesController(ILookupTableManager lookupTableManager)
        {
            this.lookupTableManager = lookupTableManager;
        }

        [HttpGet]
        public ActionResult<List<LookupTableDto>> GetAllLookupTables()
        {
            var lookuptables = lookupTableManager.GetAllLookupTables();
            if (lookuptables == null)
            {
                return NotFound();
            }

            return Ok(lookuptables);

        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<LookupTableDto> GetLookupTableById(int id)
        {
            LookupTableDto? lookupdto = lookupTableManager.GetLookupTableById(id);
            if (lookupdto == null)
                return NotFound();
            return Ok(lookupdto);
        }

        [HttpGet]
        [Route("{name}")]
        public ActionResult<LookupTableDto> GetLookupTableByName(string name)
        {
            LookupTableDto? lookupdto = lookupTableManager.GetLookupTableByName(name);
            if (lookupdto == null)
                return NotFound();
            return Ok(lookupdto);
        }

        [HttpPut]
        public ActionResult CreateNewLookupTable( LookupTableDto lookupTableDto)
        {
            lookupTableManager.CreateNewLookupTable(lookupTableDto);
            return Ok();
        }

        [HttpPost]
        [Route("{id}")]

        public ActionResult UpdateLookupTableById(LookupTableDto lookupTableDto , int id)
        {
            lookupTableManager.UpdateLookupTableById(lookupTableDto, id);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteLookupTableById(int id)
        {

            try
            {
                lookupTableManager.DeleteLookupTableById(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{name}")]
        public ActionResult DeleteLookupTableByName(int name)
        {

            try
            {
                lookupTableManager.DeleteLookupTableById(name);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");


            }
        }
    }
}
