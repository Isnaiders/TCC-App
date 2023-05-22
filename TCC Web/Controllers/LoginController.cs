using Microsoft.AspNetCore.Mvc;
using TCC_Web.Models;

namespace TCC_Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Index", "Home");
                }
                return View("Index");

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Ops, algo deu errado! Por favor, tente novamente mais tarde: {ex.Message}";
                throw;
            }
        }
    }
}
