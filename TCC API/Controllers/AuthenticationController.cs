using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TCC_API.Interfaces.Repositories;
using TCC_API.Models.DTOs.Authentication;
using TCC_API.Models.Entities.Authentication;

namespace TCC_API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AuthenticationController : Controller
	{
		public readonly IMapper _mapper;
		public readonly IAuthenticationRepository _authenticationRepository;

		public AuthenticationController(IMapper mapper, IAuthenticationRepository authenticationRepository)
		{
			_mapper = mapper;
			_authenticationRepository = authenticationRepository;
		}

		[HttpGet("GetById/{userId}")]
		public async Task<ActionResult<Authentication>> GetUserById(Guid userId)
		{
			var authenticationDB = await _authenticationRepository.GetById(userId);

			if (authenticationDB == null)
			{
				return NotFound("Usuário não encontrado.");
			}

			var authenticationDTO = _mapper.Map<Authentication>(authenticationDB);
			return Ok(authenticationDTO);
		}

		[HttpPost("Add")]
		public async Task<ActionResult> AddUser(AuthenticationDetailedDTO authenticationDTO)
		{
			var authenticationDB = _mapper.Map<Authentication>(authenticationDTO);
			_authenticationRepository.Add(authenticationDB);

			if (await _authenticationRepository.SaveAllAsync())
			{
				return Ok("Usuário cadastrado com sucesso!");
			}

			return BadRequest("Ocorreu um erro ao salvar o usuário.");
		}

		[HttpPut("Update")]
		public async Task<ActionResult> UpdateUser(AuthenticationDetailedDTO authenticationDTO)
		{
			var authenticationDB = await _authenticationRepository.GetById(authenticationDTO.UserId);

			if (authenticationDB == null)
			{
				return BadRequest("Usuário não encontrado.");
			}

			authenticationDB.UserName = authenticationDTO.UserName;
			authenticationDB.Password = authenticationDTO.Password;
			authenticationDB.User.Name = authenticationDTO.User.Name;
			authenticationDB.User.Type = authenticationDTO.User.Type;
			authenticationDB.User.Email = authenticationDTO.User.Email;
			authenticationDB.User.BirthDate = authenticationDTO.User.BirthDate;
			authenticationDB.User.LicenseDrive = authenticationDTO.User.LicenseDrive;
			authenticationDB.User.WhenUpdated = DateTime.UtcNow;
			authenticationDB.User.SystemStatus = authenticationDTO.User.SystemStatus;

			_authenticationRepository.Update(authenticationDB);

			if (await _authenticationRepository.SaveAllAsync())
			{
				return Ok("Usuário alterado com sucesso!");
			}

			return BadRequest("Ocorreu um erro ao alterar o usuário.");
		}

		[HttpDelete("Remove/{userId}")]
		public async Task<ActionResult> RemoveUser(Guid userId)
		{
			var validationResult = _authenticationRepository.Remove(userId);

			if (!string.IsNullOrEmpty(validationResult.ErrorMessage))
			{
				return NotFound(validationResult.ErrorMessage);
			}

			if (await _authenticationRepository.SaveAllAsync())
			{
				return Ok("Usuário foi removido com sucesso!");
			}

			return BadRequest("Ocorreu um erro ao remover o usuário.");
		}

		[HttpGet("Login")]
		public bool Login(AuthenticationDetailedDTO authenticationDTO)
		{
			return _authenticationRepository.Login(authenticationDTO.UserName, authenticationDTO.Password);
		}
	}
}
