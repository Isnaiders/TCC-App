using System.ComponentModel.DataAnnotations;

namespace TCC_Web.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o Usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Digite a Senha")]
        public string Password { get; set; }
    }
}
