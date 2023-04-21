using HireMeBLL;
using HireMeDAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMePL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupTablesController : ControllerBase
    {
        #region Constructor & Ingect All Required
        private readonly ILookupTableManager lookupTableManager;

        public LookupTablesController(ILookupTableManager lookupTableManager)
        {
            this.lookupTableManager = lookupTableManager;
        }

        #endregion

        #region Lookup Table Cruds ( End Ponts )

        #region Crud to get all Lookup Table With its Look up values ( values ---> list of value )
        [HttpGet]
        [Route("GetAllLookupTables")]
        public ActionResult<List<LookupTableDto>> GetAllLookupTables()
        {
            var lookuptables = lookupTableManager.GetAllLookupTables();
            if (lookuptables == null)
            {
                return NotFound(new { message=" there is no Lookup Tables here !!"});
            }
            return Ok(lookuptables);
        }
        #endregion

        #region Crud to get specific Lookup Table with its Id and get its lookup values 
        [HttpGet]
        [Route("GetLookupTableById/{id}")]
        public ActionResult<LookupTableDto> GetLookupTableById(int id)
        {
            LookupTableDto? lookupdto = lookupTableManager.GetLookupTableById(id);
            if (lookupdto == null)
                return NotFound( new {message=$" This Lookup Table With Id={id} is not Found !! "});
            return Ok(lookupdto);
        }
        #endregion


        #region Crud to create new look up table to system 
        [HttpPost]
        [Route("CreateNewLookupTable")]
        [Authorize(policy:"Admin")]
        public ActionResult CreateNewLookupTable([FromBody] string lookupname)
        {
            try
            {
                if(lookupTableManager.CreateNewLookupTable(lookupname))
                {
                    return Ok(new { message = " new lookup table added successfully !! " });
                }
                return BadRequest(new {Message="Somethign went wrong"});
            }catch  (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        #endregion

        #region Crud to Update lookup table with its Id 
        [HttpPut]
        [Route("UpdateLookupTableById/{id}")]
        [Authorize(policy:"Admin")]
        public ActionResult UpdateLookupTableById([FromBody] string name , int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if(lookupTableManager.UpdateLookupTableById(name, id))
                {
                return Ok(new {message=$" lookup table with Id = {id} is updated successfully !!"});

                }
                else
                {
                    return BadRequest(new { message="Something went wrong"});
                }

            }
            catch( Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        #endregion

        #region Crud to delete specific lookup table with its id 
        [HttpDelete]
        [Route("DeleteLookupTableById/{id}")]
        [Authorize(policy:"Admin")]
        public ActionResult DeleteLookupTableById(int id)
        {

            try
            {
                if(lookupTableManager.DeleteLookupTableById(id))
                {
                return Ok(new { message = $" lookup table with name = {id} is successfully deleted !!" });

                }else
                { return BadRequest(new { message = "something went wrong" }); };

            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        #endregion

        #endregion
    }
}
