using Business.Abstract;
using DTO.EntityDTO;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(UserDTO p)
        {
            var values = _userService.Login(p);
            Authenticate(values);


            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserDTO p)
        {
            _userService.Insert(p);
            return RedirectToAction("SignIn");
        }

        private void Authenticate(UserDTO user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.ID.ToString()),
                new Claim("Username", user.Username),
                new Claim(ClaimTypes.Role, user.RoleName),
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie");

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

    }
}
