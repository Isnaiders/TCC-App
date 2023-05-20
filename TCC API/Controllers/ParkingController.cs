using Microsoft.AspNetCore.Mvc;
using TCC_API.Interfaces;
using TCC_API.Models.Entities;

namespace TCC_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingController : Controller
    {
        public readonly IParkingRepository _parkingRepository;

        public ParkingController(IParkingRepository parkingRepository)
        {
            _parkingRepository = parkingRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Parking>>> GetAllParking()
        {
            return Ok(await _parkingRepository.GetAll());
        }

        [HttpGet("GetById/{parkingId}")]
        public async Task<ActionResult> GetParkingById(Guid parkingId)
        {
            var parkingDB = await _parkingRepository.GetById(parkingId);

            if (parkingDB == null)
            {
                return NotFound("Estacionamento não encontrado.");
            }

            return Ok(parkingDB);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddParking(Parking parking)
        {
            _parkingRepository.Add(parking);

            if (await _parkingRepository.SaveAllAsync())
            {
                return Ok("Estacionamento cadastrado com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao salvar o estacionamento");
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateParking(Parking parking)
        {
            _parkingRepository.Update(parking);

            if (await _parkingRepository.SaveAllAsync())
            {
                return Ok("Estacionamento alterado com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao alterar o estacionamento");
        }

        [HttpDelete("Remove/{parkingId}")]
        public async Task<ActionResult> RemoveParking(Guid parkingId)
        {
            var validationResult = _parkingRepository.Remove(parkingId);

            if (!string.IsNullOrEmpty(validationResult.ErrorMessage))
            {
                return NotFound(validationResult.ErrorMessage);
            }

            if (await _parkingRepository.SaveAllAsync())
            {
                return Ok("Estacionamento foi removido com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao remover o estacionamento");
        }
    }
}
