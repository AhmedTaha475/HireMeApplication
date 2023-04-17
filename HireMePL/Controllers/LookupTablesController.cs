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

        #region Crud to get specific Lookup Table with its Name and get its lookup values 
        [HttpGet]
        [Route("GetLookupTableByName/{name}")]
        public ActionResult<LookupTableDto> GetLookupTableByName(string name)
        {
            LookupTableDto? lookupdto = lookupTableManager.GetLookupTableByName(name);
            if (lookupdto == null)
                return NotFound(new {message=$" this lookup table with name = {name} is not found !! "});
            return Ok(lookupdto);
        }
        #endregion

        #region Crud to create new look up table to system 
        [HttpPut]
        [Route("CreateNewLookupTable")]
        public ActionResult CreateNewLookupTable( LookupTableDto lookupTableDto)
        {
            lookupTableManager.CreateNewLookupTable(lookupTableDto);
            return Ok(new { message=" new lookup table added successfully !! "});
        }
        #endregion

        #region Crud to Update lookup table with its Id 
        [HttpPost]
        [Route("UpdateLookupTableById/{id}")]

        public ActionResult UpdateLookupTableById(LookupTableDto lookupTableDto , int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                lookupTableManager.UpdateLookupTableById(lookupTableDto, id);
                return Ok(new {message=$" lookup table with Id = {id} is updated successfully !!"});

            }
            catch( Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        #endregion

        #region Crud to Update lookup table with its Name
        [HttpPost]
        [Route("UpdateLookupTableById/{name}")]

        public ActionResult UpdateLookupTableByName(LookupTableDto lookupTableDto, string name)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                lookupTableManager.UpdateLookupTableByName(lookupTableDto,name);
                return Ok(new { message = $" lookup table with Id = {name} is updated successfully !!" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        #endregion

        #region Crud to delete specific lookup table with its id 
        [HttpDelete]
        [Route("DeleteLookupTableById/{id}")]
        public ActionResult DeleteLookupTableById(int id)
        {

            try
            {
                lookupTableManager.DeleteLookupTableById(id);
                return Ok(new { message = $" lookup table with name = {id} is successfully deleted !!" });

            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        #endregion

        #region Crud to delete specific lookup table with its name

        [HttpDelete]
        [Route("DeleteLookupTableByName/{name}")]
        public ActionResult DeleteLookupTableByName(int name)
        {

            try
            {
                lookupTableManager.DeleteLookupTableById(name);
                return Ok(new {message=$" lookup table with name = {name} is successfully deleted !!"});

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
