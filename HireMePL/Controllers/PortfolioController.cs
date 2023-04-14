using Microsoft.AspNetCore.Mvc;

namespace HireMePL.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
