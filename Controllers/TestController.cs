using Microsoft.AspNetCore.Mvc;

namespace MEDIplan.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
