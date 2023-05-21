using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TCC_Web.Models.Entities.Base;

namespace TCC_Web.Models.Entities.Authentication
{
    public class Authentication : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        [Required]
        [StringLength(255)]
        public string UserName { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Authentication")]
        public virtual User.User User { get; set; }
    }
}