using TCC_Web.Models.Enum.Parking;

namespace TCC_Web.Models.Car
{
    public class Vacancy
	{
        public Guid ParkingId { get; set; }
        public string Name { get; set; }
        public bool Busy { get; set; }
        public VacancyType Type { get; set; }
    }
}
