using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TCC_Web.Models;
using TCC_Web.Models.Entities.Parking;
using TCC_Web.Models.Entities.User;
using TCC_Web.Services;

namespace TCC_Web.Controllers
{
	public class UserController : Controller
	{
		private readonly ILogger<UserController> _logger;
		private readonly ApiService _apiService;

		public UserController(ILogger<UserController> logger, ApiService apiService)
		{
			_logger = logger;
			_apiService = apiService;
		}

		public async Task<IActionResult> Index()
		{
			return View();
		}

		public IActionResult Add()
		{
			var model = new User();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(User model)
		{
			string postBody = JsonConvert.SerializeObject(model);

			string apiUrl = "https://localhost:7094/User/Add";
			string message = await _apiService.PostApiData(apiUrl, postBody);

			// Desserializar os dados da API em um objeto
			if (message == "Estacionamento cadastrado com sucesso!")
			{
				return RedirectToAction("Index", "Home");
			}

			return View(model);
		}
	}
}
