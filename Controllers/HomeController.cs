using Microsoft.AspNetCore.Mvc;

namespace MEDIplan.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
