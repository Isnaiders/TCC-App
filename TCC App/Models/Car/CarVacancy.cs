using TCC_App.Models.Base;

namespace TCC_App.Models.Car
{
    public class CarVacancy : BaseModel
    {
        public Guid CartId { get; set; }
        public Guid VacancyId { get; set; }
        public DateTime StartDate { get; set; }
    }
}