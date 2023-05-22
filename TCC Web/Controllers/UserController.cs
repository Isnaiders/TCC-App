using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TCC_Web.Models;
using TCC_Web.Models.DTOs.User;
using TCC_Web.Models.Entities.Authentication;
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
			var userList = new List<UserDetailedDTO>();
			string apiUrl = "https://localhost:7094/User/GetAll";
			try
			{
				string apiData = await _apiService.GetApiData(apiUrl);
				// Desserializar os dados da API em um objeto
				userList = JsonConvert.DeserializeObject<List<UserDetailedDTO>>(apiData);
			}
			catch (Exception ex)
			{
				TempData["ErrorMessage"] = "Ocorreu um erro ao obter os dados do banco de dados: " + ex.Message;
				return View(userList);
			}

			return View(userList);
		}

		public IActionResult AuthenticationAdd()
		{
			var model = new AuthenticationDTO();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> AuthenticationAdd(AuthenticationDTO model)
		{
			model.UserName = model.User.Email;
			string postBody = JsonConvert.SerializeObject(model);

			string apiUrl = "https://localhost:7094/Authentication/Add";
			string message = await _apiService.PostApiData(apiUrl, postBody);

			// Desserializar os dados da API em um objeto
			if (message == "Usuário cadastrado com sucesso!")
			{
				return RedirectToAction("Index", "Home");
			}

			return View(model);
		}
	}
}
