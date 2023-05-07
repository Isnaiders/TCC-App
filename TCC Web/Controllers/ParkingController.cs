using Microsoft.AspNetCore.Mvc;
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

        public IActionResult ParkingAdd()
        {
            var model = new Parking();
            //ViewData["Title"] = "Filtragem";

            return View(model);
        }

        [HttpPost]
        public IActionResult ParkingAdd(Parking model)
        {
            return View(model);
        }
    }
}
