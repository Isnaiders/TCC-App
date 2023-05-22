using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TCC_Web.Models.DTOs.Base;

namespace TCC_Web.Models.DTOs.User
{
	public class AuthenticationDTO : BaseDTO
	{
        public AuthenticationDTO() : base()
        {
			User = new UserDetailedDTO();
			UserId = User.Id;
        }

        [Required]
		[StringLength(255)]
		public string UserName { get; set; }

		[Required]
		[StringLength(255)]
		public string Password { get; set; }

		[ForeignKey("UserId")]
		[InverseProperty("Authentication")]
		public Guid UserId { get; set; }

		public UserDetailedDTO User { get; set; }
	}
}
