using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TCC_App.Models.Enum.Parking
{
    public enum ParkingLocationType : int
    {
        [Display(Name = "Desconhecido")]
        Unknown = 0,
        [Display(Name = "Rua")]
        Street = 1,
        [Display(Name = "Shopping")]
        ShoppingMall = 2,
        [Display(Name = "Aeroporto")]
        Airport = 3,
        [Display(Name = "Show")]
        Show = 4
    }
}