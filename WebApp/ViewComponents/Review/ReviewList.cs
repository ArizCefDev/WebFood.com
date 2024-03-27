using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents.Review
{
    public class ReviewList : ViewComponent
    {
        private readonly ICustomerService _customerService;

        public ReviewList(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _customerService.GetAll();
            return View(values);
        }
    }
}
