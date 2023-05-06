using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_App.Models.Car
{
    public class CarVacancy
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public Guid VacancyId { get; set; }
        public DateTime StartDate { get; set; }
    }
}
