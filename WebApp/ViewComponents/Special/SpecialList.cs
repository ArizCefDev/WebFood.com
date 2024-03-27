using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents.Special
{
    public class SpecialList : ViewComponent
    {
        private readonly IMenuSerice _menuSerice;

        public SpecialList(IMenuSerice menuSerice)
        {
            _menuSerice = menuSerice;
        }

        public IViewComponentResult Invoke()
        {
            var values = _menuSerice.GetAllInclude().Where(x => x.Status == "special");
            return View(values);
        }
    }
}
