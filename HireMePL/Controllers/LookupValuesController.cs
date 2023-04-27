using HireMeBLL;
using HireMeBLL.Dtos.LookupValuesDtos;
using HireMeDAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMePL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupValuesController : ControllerBase
    {
        #region Constructor & Ingect All Required
        private readonly ILookupValueManager lookupValueManager;

        public LookupValuesController( ILookupValueManager lookupValueManager)
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
        
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<LookupValueDTO>> GetAllLookupValues()
        {
            var valueList= lookupValueManager.GetAllLookupValues();
            if (valueList != null)
            {
                return Ok(valueList);
            }return NotFound(new { Message = " Values are empty" });

        }

        [HttpGet]
        [Route("GetValueById/{id}")]

        public ActionResult<LookupValueDTO> GetLookUpValueByid(int id)
        {
            var value=lookupValueManager.GetLookupValueById(id);
            if(value != null)
                return Ok(value);
            else
            {
                return NotFound(new { message = "Value not found" });
            }
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
        [Authorize(policy:"Admin")]
        public ActionResult CreateLookupValue(CreateLookupValueDto lookvaluedto)
        {
           if(lookupValueManager.CreateLookupValue(lookvaluedto))
            return Ok(new { message = $" new lookup value added successfully to lookup table with Id= {lookvaluedto.LookupId} !!" });
           return BadRequest(new { message="something went wrong"});

        }
        #endregion

        #region Crud to Delete Lookup Value by its Id

        [HttpDelete]
        [Route(" DeleteLookupValueById/{id}")]
        [Authorize(policy:"Admin")]
        public ActionResult DeleteLookupValueById(int id)
        {
            try
            {
                if(lookupValueManager.DeleteLookupValueById(id))
                    return Ok(new { message = $" lookup value with id = {id} is successfully deleted !!" });
                return NotFound(new {message="Id Not found"});
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion

        [HttpPut]
        [Route("UpdateLookupValueById/{id}")]
        [Authorize(policy:"Admin")]
        public ActionResult UpdateLookupValueById(string ValueName , int id )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if(lookupValueManager.UpdateLookupValueById(ValueName, id))
                    return Ok(new { message = $" lookup table with Id = {id} is updated successfully !!" });
                return BadRequest(new { message = "Something went wrong" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }



        }


        #endregion
    }
}
