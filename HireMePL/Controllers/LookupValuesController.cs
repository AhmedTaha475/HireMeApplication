using HireMeBLL;
using HireMeBLL.Dtos.LookupValuesDtos;
using HireMeDAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMePL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupValuesController : ControllerBase
    {
        #region Constructor & Ingect All Required
        private readonly LookupValueManager lookupValueManager;

        public LookupValuesController( LookupValueManager lookupValueManager)
        {
            this.lookupValueManager = lookupValueManager;
        }

        #endregion

        #region Lookup Values Cruds ( End Ponts )

        #region Crud to get all lookup values depende on lookup table id 

        [HttpGet]
        [Route("GetLookupValuesByLookupId/{id}")]

        public ActionResult<List<LookupValueDTO>> GetLookupValuesByLookupId(int id)
        {
            var lookupvaluesdtolist = lookupValueManager.GetLookupValuesByLookupId(id);
            if (lookupvaluesdtolist is null)
                return NotFound(new { message = " there are no lookup values !!" });
            return Ok(lookupvaluesdtolist);
        }

        #endregion

        #region Crud to get all lookup values depende on lookup table name 

        [HttpGet]
        [Route("GetLookupValuesByLookupName/{name}")]

        public ActionResult<List<LookupValueDTO>> GetLookupValuesByLookupName( string name)
        {
            var lookupvaluesdtolist = lookupValueManager.GetLookupValuesByLookupName(name);
            if (lookupvaluesdtolist is null)
                return NotFound(new { message = " there are no lookup values !!" });
            return Ok(lookupvaluesdtolist);
        }

        #endregion

        #region Crud to Create new lookup valiue to specific lookup table
        [HttpPost]
        [Route("CreateLookupValue")]
        public ActionResult CreateLookupValue( LookupValueDTO lookvaluedto)
        {
            lookupValueManager.CreateLookupValue(lookvaluedto);
            return Ok(new { message = $" new lookup value added successfully to lookup table with Id= {lookvaluedto.LookupId} !!" });


        }
        #endregion

        #region Crud to Delete Lookup Value by its Id

        [HttpDelete]
        [Route(" DeleteLookupValueById/{id}")]

        public ActionResult DeleteLookupValueById(int id)
        {
            try
            {
                lookupValueManager.DeleteLookupValueById(id);
                return Ok(new { message = $" lookup value with id = {id} is successfully deleted !!" });

            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion

        [HttpPut]
        [Route("UpdateLookupValueById/{id}")]
        public ActionResult UpdateLookupValueById(LookupValueDTO lookupValueDTO , int id )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                lookupValueManager.UpdateLookupValueById(lookupValueDTO , id);
                return Ok(new { message = $" lookup table with Id = {id} is updated successfully !!" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }



        }


        #endregion
    }
}
