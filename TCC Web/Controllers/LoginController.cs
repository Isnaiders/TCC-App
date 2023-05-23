using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TCC_Web.Models;
using TCC_Web.Services;

namespace TCC_Web.Controllers
{
	public class LoginController : Controller
	{
		private readonly ApiService _apiService;

		public LoginController(ApiService apiService)
		{
			_apiService = apiService;
		}

		public IActionResult Index()
		{
			var model = new LoginModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginModel model)
		{
			string apiUrl = "https://localhost:7094/Authentication/Login";
			try
			{
				string postBody = JsonConvert.SerializeObject(model);
				var result = Convert.ToBoolean(await _apiService.PostApiData(apiUrl, postBody));

				if (ModelState.IsValid && result)
				{
					return RedirectToAction("Index", "Home");
				}

				return View("Index", model);
			}
			catch (Exception ex)
			{
				TempData["ErrorMessage"] = "Ocorreu um erro ao obter os dados do banco de dados: " + ex.Message;
				return View("Index", model);
			}
		}
	}
}
