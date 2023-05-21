using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using TCC_API.Models.Entities.Base;

namespace TCC_API.Models.Entities.User
{
    [Serializable]
    public partial class User : BaseEntity<Guid>
    {
        public User()
        {
            Authentication = new HashSet<Authentication.Authentication>();
        }

        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string Name { get; set; }
        public int Type { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string Email { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime BirthDate { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string LicenseDrive { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Authentication.Authentication> Authentication { get; set; }
    }
}