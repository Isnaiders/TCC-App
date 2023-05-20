using TCC_Web.Models.Base;
using TCC_Web.Models.Enum.Parking;

namespace TCC_Web.Models.Parking
{
    public class ParkingReservationHistory : BaseModel
    {
        public Guid ParkingId { get; set; }
        public Guid VacancyId { get; set; }
        public Guid CartId { get; set; }
        public VacancyType VacancyType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? CommitedStartDate { get; set; }
        public DateTime? CommitedEndDate { get; set; }
    }
}
