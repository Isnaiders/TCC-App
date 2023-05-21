using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TCC_API.Models.DTOs.Base;

namespace TCC_API.Models.DTOs.User
{
    public class UserDetailedDTO : BaseDTO
    {
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string Name { get; set; }

        public int Type { get; set; }

        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string LicenseDrive { get; set; }
    }
}
