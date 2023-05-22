using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TCC_API.Models.DTOs.Base;

namespace TCC_API.Models.DTOs.User
{
    public class UserDetailedDTO : BaseDTO
    {
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
