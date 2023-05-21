using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using TCC_API.Models.Entities.Base;
using TCC_API.Models.Entities.User;

namespace TCC_API.Models.Entities.Parking
{
    [Index("CarId", Name = "IX_CarId")]
    [Index("ParkingId", Name = "IX_ParkingId")]
    [Index("VacancyId", Name = "IX_VacancyId")]
    [Serializable]
    public partial class ParkingReservation : BaseEntity<Guid>
    {
        public Guid ParkingId { get; set; }
        public Guid? VacancyId { get; set; }
        public Guid CarId { get; set; }
        public int VacancyType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CommittedStartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CommittedEndDate { get; set; }

        [ForeignKey("CarId")]
        [InverseProperty("ParkingReservation")]
        public virtual Car Car { get; set; }
        [ForeignKey("ParkingId")]
        [InverseProperty("ParkingReservation")]
        public virtual Parking Parking { get; set; }
        [ForeignKey("VacancyId")]
        [InverseProperty("ParkingReservation")]
        public virtual Vacancy Vacancy { get; set; }
    }
}