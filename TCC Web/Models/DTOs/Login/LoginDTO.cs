using System.ComponentModel.DataAnnotations;

namespace TCC_Web.Models.DTOs.Login
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Digite o Usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        public string Password { get; set; }
    }
}
