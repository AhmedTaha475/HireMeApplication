using HireMeBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMePL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupTablesController : ControllerBase
    {
        private readonly ILookupTableManager lookupTableManager;

        public LookupTablesController( ILookupTableManager lookupTableManager)
        {
            this.lookupTableManager = lookupTableManager;
        }

        [HttpGet]

        public ActionResult<List<LookupTableDto>> GetAllLookupTables()
        {
            var lookuptables = lookupTableManager.GetAllLookupTables();
            if(lookuptables == null)
            {
                return NotFound();
            }           
            
                Ok(lookuptables);
            

        }
    }
}
