using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TCC_App.Models.Enum.Base;

namespace TCC_API.Models.DTOs
{
    public class UserDetailedDTO
    {
        #region Base Properties
        public Guid Id { get; set; }
        public DateTime WhenCreated { get; set; }
        public DateTime? WhenUpdated { get; set; }
        public DateTime? WhenRemoved { get; set; }
        public SystemStatusType SystemStatus { get; set; }
        #endregion

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
