using Business.Abstract;
using DTO.EntityDTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMessageService _messageService;

        public ContactController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(MessageDTO p)
        {
            _messageService.Insert(p);
            return RedirectToAction("Message");
        }

        public IActionResult Message()
        {
            return View();
        }
    }
}
