using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuSerice _menuSerice;

        public MenuController(IMenuSerice menuSerice)
        {
            _menuSerice = menuSerice;
        }

        public IActionResult Index(string search)
        {
            var values = from x in _menuSerice.GetAllInclude() select x;
            if (!string.IsNullOrEmpty(search))
            {
                values = values.Where(title => title.Title.ToLower().Contains(search.ToLower()));
                ViewBag.i = search;
            }
            return View(values);
        }
    }
}
