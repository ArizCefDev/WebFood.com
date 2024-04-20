using Business.Abstract;
using DataAccess.Context;
using DTO.EntityDTO;
using Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Controllers
{
    [Authorize(Roles =RoleKeywords.AdminRole)]
    public class AdminController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IMessageService _messageService;
        private readonly IContactService _contactService;
        private readonly ICategoryService _categoryService;
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMenuSerice _menuSerice;
        private readonly AppDBContext _dBContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(IAboutService aboutService, IMessageService messageService, IContactService contactService, ICategoryService categoryService, ISocialMediaService socialMediaService, IMenuSerice menuSerice, AppDBContext dBContext, IWebHostEnvironment webHostEnvironment)
        {
            _aboutService = aboutService;
            _messageService = messageService;
            _contactService = contactService;
            _categoryService = categoryService;
            _socialMediaService = socialMediaService;
            _menuSerice = menuSerice;
            _dBContext = dBContext;
            _webHostEnvironment = webHostEnvironment;
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
            return View(values);
        }

        [HttpGet]
        public IActionResult AboutAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AboutAdd(AboutDTO dto, IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
            {
                return Content("Foto secilmeyib");
            }
            else
            {
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", photo.FileName);
                var stream = new FileStream(path, FileMode.Create);
                photo.CopyToAsync(stream);
                dto.ImageURL = photo.FileName;
            }
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
        public IActionResult AboutUpdate(AboutDTO dto,IFormFile photo)
        {
            if (photo != null)
            {
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", photo.FileName);
                var stream = new FileStream(path, FileMode.Create);
                photo.CopyToAsync(stream);
                dto.ImageURL = photo.FileName;
            }
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
            return View(values.OrderByDescending(x => x.ID));
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

        #region SocialMedia Page
        public IActionResult SocialMedia()
        {
            var values = _socialMediaService.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult SocialMediaAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SocialMediaAdd(SocialMediaDTO dto)
        {
            _socialMediaService.Insert(dto);
            return RedirectToAction("SocialMedia");
        }

        [HttpGet]
        public IActionResult SocialMediaUpdate(int id)
        {
            var values = _socialMediaService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult SocialMediaUpdate(SocialMediaDTO dto)
        {
            _socialMediaService.Update(dto);
            return RedirectToAction("SocialMedia");
        }

        public IActionResult SocialMediaDelete(int id)
        {
            _socialMediaService.Delete(id);
            return RedirectToAction("SocialMedia");
        }
        #endregion


        #region Menu Page
        public IActionResult Menu()
        {
            var values = _menuSerice.GetAllInclude();
            return View(values);
        }

        [HttpGet]
        public IActionResult MenuAdd()
        {
            IEnumerable<SelectListItem> valueGet = (from x in _categoryService.GetAll()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.ID.ToString()
                                                    }).ToList();
            ViewBag.c = valueGet;
            return View();
        }

        [HttpPost]
        public IActionResult MenuAdd(MenuDTO dto)
        {
            IEnumerable<SelectListItem> valueGet = (from x in _categoryService.GetAll()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.ID.ToString()
                                                    }).ToList();
            ViewBag.c = valueGet;
            dto.Date = DateTime.Now;
            _menuSerice.Insert(dto);
            return RedirectToAction("Menu");
        }

        [HttpGet]
        public IActionResult MenuUpdate(int id)
        {
            IEnumerable<SelectListItem> valueGet = (from x in _categoryService.GetAll()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.ID.ToString()
                                                    }).ToList();
            ViewBag.c = valueGet;
            var values = _menuSerice.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult MenuUpdate(MenuDTO dto)
        {
            IEnumerable<SelectListItem> valueGet = (from x in _categoryService.GetAll()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.ID.ToString()
                                                    }).ToList();
            ViewBag.c = valueGet;
            _menuSerice.Update(dto);
            return RedirectToAction("Menu");
        }

        public IActionResult MenuDelete(int id)
        {
            _menuSerice.Delete(id);
            return RedirectToAction("Menu");
        }
        #endregion
    }
}
