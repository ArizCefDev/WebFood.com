﻿using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
    }
}
