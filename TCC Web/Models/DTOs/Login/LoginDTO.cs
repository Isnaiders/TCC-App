using System.ComponentModel.DataAnnotations;

namespace TCC_Web.Models.DTOs.Login
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Digite o Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite a Senha")]
        public string Password { get; set; }
    }
}
