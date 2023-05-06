using TCC_Web.Models.Base;
using TCC_Web.Models.Enum.Parking;

namespace TCC_Web.Models.Parking
{
    public class Parking : BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public ParkingLocationType LocationType { get; set; }
    }
}
