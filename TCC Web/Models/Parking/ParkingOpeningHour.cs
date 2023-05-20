using TCC_Web.Models.Base;
using TCC_Web.Models.Enum.Parking;

namespace TCC_Web.Models.Parking
{
    public class ParkingOpeningHour : BaseModel
	{
        public Guid ParkingId { get; set; }
        public OpeningDay Day { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
    }
}
