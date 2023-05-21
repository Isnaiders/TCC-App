using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TCC_Web.Models.Entities.Base;

namespace TCC_Web.Models.Entities.User
{
    public class User : BaseEntity<Guid>
    {
        public User()
        {
            Authentication = new HashSet<Authentication.Authentication>();
        }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public int Type { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime BirthDate { get; set; }
        [Required]
        [StringLength(255)]
        public string LicenseDrive { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Authentication.Authentication> Authentication { get; set; }
    }
}