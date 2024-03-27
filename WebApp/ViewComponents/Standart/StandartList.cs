using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents.Standart
{
    public class StandartList : ViewComponent
    {
        private readonly IMenuSerice _menuSerice;

        public StandartList(IMenuSerice menuSerice)
        {
            _menuSerice = menuSerice;
        }

        public IViewComponentResult Invoke()
        {
            var values = _menuSerice.GetAllInclude().Where(x => x.Status == "standart");
            return View(values);
        }
    }
}
