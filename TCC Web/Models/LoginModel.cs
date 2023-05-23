﻿using System.ComponentModel.DataAnnotations;

namespace TCC_Web.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o email")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        public string Password { get; set; }
    }
}
