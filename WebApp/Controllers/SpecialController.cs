using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class SpecialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
