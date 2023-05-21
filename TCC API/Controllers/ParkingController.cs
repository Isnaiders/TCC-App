﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TCC_API.Interfaces.Repositories;
using TCC_API.Models.DTOs.Parking;
using TCC_API.Models.Entities.Parking;

namespace TCC_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingController : Controller
    {
        public readonly IMapper _mapper;
        public readonly IParkingRepository _parkingRepository;

        public ParkingController(IMapper mapper, IParkingRepository parkingRepository)
        {
            _mapper = mapper;
            _parkingRepository = parkingRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ParkingDetailedDTO>>> GetAllParking()
        {
            var parkingDBs = await _parkingRepository.GetAll();
            var parkingDTOs = _mapper.Map<IEnumerable<ParkingDetailedDTO>>(parkingDBs);
            return Ok(parkingDTOs);
        }

        [HttpGet("GetById/{parkingId}")]
        public async Task<ActionResult> GetParkingById(Guid parkingId)
        {
            var parkingDB = await _parkingRepository.GetById(parkingId);

            if (parkingDB == null)
            {
                return NotFound("Estacionamento não encontrado.");
            }

            var parkingDTO = _mapper.Map<Parking>(parkingDB);
            return Ok(parkingDTO);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddParking(ParkingDetailedDTO parkingDTO)
        {
            var parkingDB = _mapper.Map<Parking>(parkingDTO);
            _parkingRepository.Add(parkingDB);

            if (await _parkingRepository.SaveAllAsync())
            {
                return Ok("Estacionamento cadastrado com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao salvar o estacionamento.");
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateParking(ParkingDetailedDTO parkingDTO)
        {
            var exists = _parkingRepository.Exists(parkingDTO.Id);

            if (!exists)
            {
                return BadRequest("Estacionamento não encontrado.");
            }

            var parkingDB = _mapper.Map<Parking>(parkingDTO);
            _parkingRepository.Update(parkingDB);

            if (await _parkingRepository.SaveAllAsync())
            {
                return Ok("Estacionamento alterado com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao alterar o estacionamento.");
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

            return BadRequest("Ocorreu um erro ao remover o estacionamento.");
        }
    }
}
