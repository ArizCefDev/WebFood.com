using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ICustomerService _customerService;

        public ReviewController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var values=_customerService.GetAll();
            return View(values);
        }
    }
}
