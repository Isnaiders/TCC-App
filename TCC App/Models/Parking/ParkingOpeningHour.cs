using TCC_App.Models.Base;
using TCC_App.Models.Enum.Parking;

namespace TCC_App.Models.Parking
{
    public class ParkingOpeningHour : BaseModel
	{
        public DateTime OpeningHour { get; set; }
        public DateTime ClosingHour { get; set; }
        public OpeningDay Day { get; set; }
        public Guid ParkingId { get; set; }
    }
}