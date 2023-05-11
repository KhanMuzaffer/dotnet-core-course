using AuthBasic.Interfaces;
using AuthBasic.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthBasic.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly IHttpContextAccessor _httpContext;

        public UserController(IUserRepository repository, IHttpContextAccessor _httpContext)
        {
            _repository = repository;
            this._httpContext = _httpContext;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            bool result = await _repository.Login(model);
            if (result)
            {
                TempData["result"] = "Login successful!";
                return RedirectToAction("Index", "Home");
            }
            TempData["error"] = "Login failed!";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserVM model)
        {
            var result = await CheckEmail(model.Email) as JsonResult;
            bool emailAvailable = (bool)result.Value;

            if (emailAvailable)
            {
                TempData["error"] = "Email already exists in database!";
                return View();
            }

            bool registerResult = await _repository.Register(model);
            if (registerResult)
            {
                TempData["result"] = "Register successful!";
                return RedirectToAction(nameof(Login));
            }
            TempData["error"] = "Register failed!";
            return View();
        }


        public IActionResult LogOut()
        {
            _httpContext.HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> CheckEmail(string email)
        {
            bool result = await _repository.IsEmailAvailable(email);
            if (result)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

    }
}
