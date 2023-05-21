using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using TCC_API.Models.Entities.Base;

namespace TCC_API.Models.Entities.Parking
{
    [Index("ParkingId", Name = "IX_ParkingId")]
    [Serializable]
    public partial class ParkingOpeningHour : BaseEntity<Guid>
    {
        public Guid ParkingId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OpeningTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ClosingTime { get; set; }
        public int Day { get; set; }

        [ForeignKey("ParkingId")]
        [InverseProperty("ParkingOpeningHour")]
        public virtual Parking Parking { get; set; }
    }
}