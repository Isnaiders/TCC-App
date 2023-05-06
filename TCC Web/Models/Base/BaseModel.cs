using System.ComponentModel.DataAnnotations;

namespace TCC_Web.Models.Base
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime WhenCreated { get; set; }
        public DateTime? WhenUpdated { get; set; }
        public DateTime? WhenRemoved { get; set; }
        public ValidationResult ValidationResult;
    }
}
