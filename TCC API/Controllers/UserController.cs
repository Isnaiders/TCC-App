using Microsoft.AspNetCore.Mvc;
using TCC_API.Interfaces;
using TCC_API.Models.Entities;

namespace TCC_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        public readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUser()
        {
            return Ok(await _userRepository.GetAll());
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<User>> GetUserById(Guid userId)
        {
            return Ok(await _userRepository.GetById(userId));
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddUser(User user)
        {
            _userRepository.Add(user);

            if (await _userRepository.SaveAllAsync())
            {
                return Ok("Usuário cadastrado com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao salvar o usuário");
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateUser(User user)
        {
            _userRepository.Update(user);

            if (await _userRepository.SaveAllAsync())
            {
                return Ok("Usuário alterado com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao alterar o usuário");
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

            return BadRequest("Ocorreu um erro ao remover o usuário");
        }
    }
}
