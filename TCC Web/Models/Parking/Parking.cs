using TCC_Web.Models.Base;
using TCC_Web.Models.Enum.Parking;

namespace TCC_Web.Models.Parking
{
    public class Parking : BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int AddressNumber { get; set; }
        public string Complement { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public ParkingLocationType LocationType { get; set; }
        public ICollection<ParkingOpeningHour> ParkingOpeningHours { get; set; }
        public Guid CountryId { get; set; }
        public Guid CountryName { get; set; }
        public Guid StateId { get; set; }
        public Guid StateName { get; set; }
        public Guid CityId { get; set; }
        public Guid CityName { get; set; }
        public Guid NeighborhoodId { get; set; }
        public Guid NeighborhoodName { get; set; }
    }
}
