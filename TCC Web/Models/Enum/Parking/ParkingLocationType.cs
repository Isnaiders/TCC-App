using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TCC_Web.Models.Enum.Parking
{
    public enum ParkingLocationType : int
    {
        Desconhecido = 0,
        Endereço = 1,
        Shopping = 2,
        Aeroporto = 3,
        Show = 4
    }
}
