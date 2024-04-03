using Business.Abstract;
using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly AppDBContext _dBContext;

        public AdminController(IAboutService aboutService, AppDBContext dBContext)
        {
            _aboutService = aboutService;
            _dBContext = dBContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            ViewBag.count = _dBContext.Abouts.Count();

            var values = _aboutService.GetAll();
            //if (values==null)
            //{
            //    ViewBag.v= "visibility:block";
            //}
            //else
            //{
            //    ViewBag.v = "visibility:hidden";
            //}
            return View(values);
        }

        public IActionResult AboutDelete(int id)
        {
           _aboutService.Delete(id);
            return RedirectToAction("About");
        }
    }
}
