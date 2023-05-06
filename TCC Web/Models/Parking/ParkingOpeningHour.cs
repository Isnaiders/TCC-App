using TCC_Web.Models.Base;
using TCC_Web.Models.Enum.Parking;

namespace TCC_Web.Models.Parking
{
    public class ParkingOpeningHour : BaseModel
	{
        public DateTime OpeningHour { get; set; }
        public DateTime ClosingHour { get; set; }
        public OpeningDay Day { get; set; }
        public Guid ParkingId { get; set; }
    }
}
