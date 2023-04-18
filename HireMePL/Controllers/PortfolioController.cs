using HireMeBLL;
using HireMeBLL.Dtos.Portfolio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMePL
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioManager _portfolioManger;
        public PortfolioController(IPortfolioManager portfolioManager)
        {
            _portfolioManger = portfolioManager;
        }
        [HttpGet]
        public ActionResult<List<PortfolioReadDto>> GetAll()
        {
            var result= _portfolioManger.GetAll().ToList();
            if(result != null)
            {
                return Ok(result);
            }
            return NotFound(new {message="No portfolios were found"});
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<PortfolioReadDto> GetAllById(int id)
        {
            PortfolioReadDto? portfolio = _portfolioManger.GetById(id);
            if(portfolio is null)
            {
                return NotFound(new {message="Not portfolio was found"}); 
            }
            return portfolio; 
        }
        [HttpPost]
        public ActionResult AddPortfolio(string freelancerId)
        {
            try
            {
                if (_portfolioManger.AddPortfolio(freelancerId))
                    return NoContent();
                else
                    return BadRequest(new { message = "Something went wrong" });
            }catch  (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpDelete("{id}")]
        public ActionResult DeletePortfolio (int id)
        {
            try
            {
                var result = _portfolioManger.DeleteById(id);
                if (!result)
                {
                    return NotFound(new { message = "No portfolio with that id" });
                }
                return Ok(new { message = "Portfoli was deleted successfully" });
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

    }
}
