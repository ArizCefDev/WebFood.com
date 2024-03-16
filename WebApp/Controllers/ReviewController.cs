using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
