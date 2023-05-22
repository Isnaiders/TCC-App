using System.ComponentModel.DataAnnotations;
using TCC_Web.Models.DTOs.Base;

namespace TCC_Web.Models.DTOs.User
{
	public class UserDetailedDTO : BaseDTO
	{
        public UserDetailedDTO() : base()
        {
            
        }
        [Required]
		[StringLength(255)]
		public string Name { get; set; }

		public int Type { get; set; }

		[Required]
		[StringLength(255)]
		public string Email { get; set; }

		public DateTime BirthDate { get; set; }

		[Required]
		[StringLength(255)]
		public string LicenseDrive { get; set; }
	}
}
