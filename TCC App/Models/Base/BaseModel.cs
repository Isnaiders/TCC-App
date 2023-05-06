using System.ComponentModel.DataAnnotations;
using TCC_App.Models.Enum.Base;

namespace TCC_App.Models.Base
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime WhenCreated { get; set; }
        public DateTime? WhenUpdated { get; set; }
        public DateTime? WhenRemoved { get; set; }
        public SystemStatusType SystemStatus { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}