using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCC_API.Models.Entities
{
    public class Base
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime WhenCreated { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? WhenUpdated { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? WhenRemoved { get; set; }

        public int SystemStatus { get; set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }
    }
}
