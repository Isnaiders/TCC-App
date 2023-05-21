using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using TCC_API.Models.Entities.Base;

namespace TCC_API.Models.Entities.Authentication
{
    [Index("UserId", Name = "IX_UserId")]
    [Serializable]
    public partial class Authentication : BaseEntity<Guid>
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

        [ForeignKey("UserId")]
        [InverseProperty("Authentication")]
        public virtual User.User User { get; set; }
    }
}