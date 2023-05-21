using Microsoft.AspNetCore.Mvc;
using TCC_Web.Models.Car;
using TCC_Web.Models.Parking;

namespace TCC_Web.Controllers
{
    public class ParkingController : Controller
    {
        private readonly ILogger<ParkingController> _logger;

        public ParkingController(ILogger<ParkingController> logger)
        {
            _logger = logger;
        }

        public IActionResult View()
        {
            return View();
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

        public IActionResult Update()
        {
            var model = new Parking();
            model.Name = "Estacionamento Shopping Aricanduva";
            model.Address = "Rua Silvia";
            model.AddressNumber = 110;
            model.LocationType = Models.Enum.Parking.ParkingLocationType.Shopping;

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
