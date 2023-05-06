using TCC_Web.Models.Base;

namespace TCC_Web.Models.Car
{
    public class CarVacancyHistory : BaseModel
    {
        public Guid CartId { get; set; }
        public Guid VacancyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
