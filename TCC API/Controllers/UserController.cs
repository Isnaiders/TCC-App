﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TCC_API.Interfaces;
using TCC_API.Models.DTOs;
using TCC_API.Models.Entities;
using TCC_API.Repositories;

namespace TCC_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        public readonly IMapper _mapper;
        public readonly IUserRepository _userRepository;

        public UserController(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<UserDetailedDTO>>> GetAllUser()
        {
            var userDBs = await _userRepository.GetAll();
            var userDTOs = _mapper.Map<IEnumerable<UserDetailedDTO>>(userDBs);
            return Ok(userDTOs);
        }

        [HttpGet("GetById/{userId}")]
        public async Task<ActionResult<User>> GetUserById(Guid userId)
        {
            var userDB = await _userRepository.GetById(userId);

            if (userDB == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            var userDTO = _mapper.Map<User>(userDB);
            return Ok(userDTO);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddUser(UserDetailedDTO userDTO)
        {
            var userDB = _mapper.Map<User>(userDTO);
            _userRepository.Add(userDB);

            if (await _userRepository.SaveAllAsync())
            {
                return Ok("Usuário cadastrado com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao salvar o usuário.");
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateUser(UserDetailedDTO userDTO)
        {
            var exists = _userRepository.Exists(userDTO.Id);

            if (!exists)
            {
                return BadRequest("Usuário não encontrado.");
            }

            var userDB = _mapper.Map<User>(userDTO);
            _userRepository.Update(userDB);

            if (await _userRepository.SaveAllAsync())
            {
                return Ok("Usuário alterado com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao alterar o usuário.");
        }

        [HttpDelete("Remove/{userId}")]
        public async Task<ActionResult> RemoveUser(Guid userId)
        {
            var validationResult = _userRepository.Remove(userId);

            if (!string.IsNullOrEmpty(validationResult.ErrorMessage))
            {
                return NotFound(validationResult.ErrorMessage);
            }

            if (await _userRepository.SaveAllAsync())
            {
                return Ok("Usuário foi removido com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao remover o usuário.");
        }
    }
}
