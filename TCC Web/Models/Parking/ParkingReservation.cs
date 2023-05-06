using TCC_Web.Models.Base;

namespace TCC_Web.Models.Parking
{
    public class ParkingReservation : BaseModel
    {
        public Guid ParkingId { get; set; }
        public Guid CartId { get; set; }
        public DateTime StartDate { get; set; }
    }
}
