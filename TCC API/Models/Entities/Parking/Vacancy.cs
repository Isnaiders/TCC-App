using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using TCC_API.Models.Entities.Base;

namespace TCC_API.Models.Entities.Parking
{
    [Index("ParkingId", Name = "IX_ParkingId")]
    [Serializable]
    public partial class Vacancy : BaseEntity<Guid>
    {
        public Vacancy()
        {
            ParkingReservation = new HashSet<ParkingReservation>();
            ParkingReservationHistory = new HashSet<ParkingReservationHistory>();
        }

        public Guid ParkingId { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string Name { get; set; }
        public bool Busy { get; set; }
        public int Type { get; set; }

        [ForeignKey("ParkingId")]
        [InverseProperty("Vacancy")]
        public virtual Parking Parking { get; set; }
        [InverseProperty("Vacancy")]
        public virtual ICollection<ParkingReservation> ParkingReservation { get; set; }
        [InverseProperty("Vacancy")]
        public virtual ICollection<ParkingReservationHistory> ParkingReservationHistory { get; set; }
    }
}