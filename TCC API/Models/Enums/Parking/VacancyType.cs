using System.ComponentModel.DataAnnotations;

namespace TCC_App.Models.Enum.Parking
{
    public enum VacancyType : int
    {
        [Display(Name = "Não Definido")]
        Undefined = 0,
        [Display(Name = "Deficiente")]
        Deficient = 1
    }
}