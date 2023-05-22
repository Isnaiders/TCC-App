using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TCC_API.Models.DTOs.Base;
using TCC_API.Models.DTOs.User;

namespace TCC_API.Models.DTOs.Authentication
{
	public class AuthenticationDetailedDTO : BaseDTO
	{
		public Guid UserId { get; set; }
		[Required]
		[StringLength(255)]
		[Unicode(false)]
		public string UserName { get; set; }
		[Required]
		[StringLength(255)]
		[Unicode(false)]
		public string Password { get; set; }

		public UserDetailedDTO User { get; set; }
	}
}
