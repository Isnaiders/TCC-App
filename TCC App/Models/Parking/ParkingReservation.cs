using TCC_App.Models.Base;

namespace TCC_App.Models.Parking
{
    public class ParkingReservation : BaseModel
    {
        public Guid ParkingId { get; set; }
        public Guid CartId { get; set; }
        public DateTime StartDate { get; set; }
    }
}