using TCC_App.Models.Enum.Base;

namespace TCC_API.Models.DTOs
{
    public class BaseDTO
    {
        #region Base Properties
        public Guid Id { get; set; }
        public DateTime WhenCreated { get; set; }
        public DateTime? WhenUpdated { get; set; }
        public DateTime? WhenRemoved { get; set; }
        public SystemStatusType SystemStatus { get; set; }
        #endregion
    }
}
