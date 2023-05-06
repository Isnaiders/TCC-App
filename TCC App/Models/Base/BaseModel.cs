using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TCC_App.Models.Enums;

namespace TCC_App.Models.Base
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public SystemStatusType SystemStatus { get; set; }
        public DateTime WhenCreated { get; set; }
        public DateTime? WhenUpdated { get; set; }
        public DateTime? WhenRemoved { get; set; }

        [NotMapped]
        [NonSerialized]
        public ValidationResult ValidationResult;
    }
}
