using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class SpecialController : Controller
    {
        private readonly IMenuSerice _menuSerice;

        public SpecialController(IMenuSerice menuSerice)
        {
            _menuSerice = menuSerice;
        }

        public IActionResult Index()
        {
            var values = _menuSerice.GetAll().Where(x=>x.Status== "special");
            return View(values);
        }
    }
}
