using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TCC_API.Interfaces.Repositories;
using TCC_API.Models.DTOs.User;
using TCC_API.Models.Entities.User;

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
			var userDB = await _userRepository.GetById(userDTO.Id);

			if (userDB == null)
			{
				return BadRequest("Usuário não encontrado.");
			}

			userDB.Name = userDTO.Name;
			userDB.Type = userDTO.Type;
			userDB.Email = userDTO.Email;
			userDB.BirthDate = userDTO.BirthDate;
			userDB.LicenseDrive = userDTO.LicenseDrive;
			userDB.WhenUpdated = DateTime.UtcNow;
			userDB.SystemStatus = userDTO.SystemStatus;

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
