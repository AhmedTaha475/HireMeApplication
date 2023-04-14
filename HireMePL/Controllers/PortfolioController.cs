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
            return _portfolioManger.GetAll().ToList();
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<PortfolioReadDto> GetAllById(int id)
        {
            PortfolioReadDto? portfolio = _portfolioManger.GetById(id);
            if(portfolio is null)
            {
                return NotFound(); 
            }
            return portfolio; 
        }
        [HttpPost]
        public ActionResult AddPortfolio(PortfolioReadDto portfolio)
        {
           _portfolioManger.AddPortfolio(portfolio);
            return NoContent(); 
        }
        [HttpDelete("{id}")]
        public ActionResult DeletePortfolio (int id)
        {
            PortfolioReadDto? portfolio = _portfolioManger.GetById(id);
            if (portfolio is null)
            {
                return NotFound();
            }
           return NoContent(); 
        }

    }
}
