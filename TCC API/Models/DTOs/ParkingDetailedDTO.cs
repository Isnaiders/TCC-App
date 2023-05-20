using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TCC_App.Models.Enum.Base;
using TCC_App.Models.Enum.Parking;

namespace TCC_API.Models.DTOs
{
    public class ParkingDetailedDTO
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

        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string Address { get; set; }

        public int Type { get; set; }

        public ParkingLocationType LocationType { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}
