using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TCC_Web.Models.DTOs.Parking;
using TCC_Web.Models.Entities.Parking;
using TCC_Web.Models.Entities.User;
using TCC_Web.Services;

namespace TCC_Web.Controllers
{
    public class ParkingController : Controller
    {
        private readonly ILogger<ParkingController> _logger;
        private readonly ApiService _apiService;

        public ParkingController(ILogger<ParkingController> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            string apiUrl = "https://localhost:7094/Parking/GetAll";
            string apiData = await _apiService.GetApiData(apiUrl);

            return View();
        }

        public async Task<IActionResult> View(Guid id)
        {
            string apiUrl = "https://localhost:7094/Parking/GetById/" + id.ToString();
            string apiData = await _apiService.GetApiData(apiUrl);

            // Desserializar os dados da API em um objeto
            ParkingDetailedDTO model = JsonConvert.DeserializeObject<ParkingDetailedDTO>(apiData);

            return View(model);
        }

        public IActionResult Add()
        {
            var model = new Parking();

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Parking model)
        {
            return View(model);
        }

        public async Task<IActionResult> Update(Guid id)
        {
            string apiUrl = "https://localhost:7094/Parking/GetById/" + id.ToString();
            string apiData = await _apiService.GetApiData(apiUrl);

            // Desserializar os dados da API em um objeto
            Parking model = JsonConvert.DeserializeObject<Parking>(apiData);

            return View(model);
        }

        [HttpPost]
        public IActionResult ParkingUpdate(Parking model)
        {
            return View(model);
        }

        public IActionResult CarAdd()
        {
            var model = new Car();

            return View(model);
        }

        [HttpPost]
        public IActionResult CarAdd(Car model)
        {
            return View(model);
        }

        public IActionResult CarUpdate()
        {
            var model = new Car();
            model.Name = "Carro Passeio";
            model.Model = "Porsche Taycan";
            model.Plate = "1234-ABC";

            return View(model);
        }

        [HttpPost]
        public IActionResult CarUpdate(Car model)
        {
            return View(model);
        }
    }
}
