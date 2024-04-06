using Business.Abstract;
using DataAccess.Context;
using DTO.EntityDTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IMessageService _messageService;
        private readonly IContactService _contactService;
        private readonly ICategoryService _categoryService;
        private readonly AppDBContext _dBContext;

        public AdminController(IAboutService aboutService, IMessageService messageService, IContactService contactService, ICategoryService categoryService, AppDBContext dBContext)
        {
            _aboutService = aboutService;
            _messageService = messageService;
            _contactService = contactService;
            _categoryService = categoryService;
            _dBContext = dBContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        #region About Page
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

        [HttpGet]
        public IActionResult AboutAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AboutAdd(AboutDTO dto)
        {
            _aboutService.Insert(dto);
            return RedirectToAction("About");
        }

        [HttpGet]
        public IActionResult AboutUpdate(int id)
        {
            var values = _aboutService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult AboutUpdate(AboutDTO dto)
        {
            _aboutService.Update(dto);
            return RedirectToAction("About");
        }

        public IActionResult AboutDelete(int id)
        {
            _aboutService.Delete(id);
            return RedirectToAction("About");
        }
        #endregion

        #region Message Page
        public IActionResult Message()
        {
            var values = _messageService.GetAll();
            return View(values.OrderByDescending(x=>x.ID));
        }

        public IActionResult MessageDelete(int id)
        {
            _messageService.Delete(id);
            return RedirectToAction("Message");
        }
        #endregion

        #region Contact Page

        public IActionResult Contact()
        {
            ViewBag.count = _dBContext.Contacts.Count();

            var values = _contactService.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult ContactAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactAdd(ContactDTO dto)
        {
            _contactService.Insert(dto);
            return RedirectToAction("Contact");
        }

        public IActionResult ContactDelete(int id)
        {
            _contactService.Delete(id);
            return RedirectToAction("Contact");
        }
        #endregion

        #region Category Page

        public IActionResult Category()
        {
            var values = _categoryService.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(CategoryDTO dto)
        {
            _categoryService.Insert(dto);
            return RedirectToAction("Category");
        }

        public IActionResult CategoryDelete(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Category");
        }
        #endregion


    }
}
