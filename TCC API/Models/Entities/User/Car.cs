using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using TCC_API.Models.Entities.Base;
using TCC_API.Models.Entities.Parking;

namespace TCC_API.Models.Entities.User
{
    [Serializable]
    public partial class Car : BaseEntity<Guid>
    {
        public Car()
        {
            ParkingReservation = new HashSet<ParkingReservation>();
            ParkingReservationHistory = new HashSet<ParkingReservationHistory>();
        }

        public Guid UserId { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string Plate { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string Model { get; set; }

        [InverseProperty("Car")]
        public virtual ICollection<ParkingReservation> ParkingReservation { get; set; }
        [InverseProperty("Car")]
        public virtual ICollection<ParkingReservationHistory> ParkingReservationHistory { get; set; }
    }
}