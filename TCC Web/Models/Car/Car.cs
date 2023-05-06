using TCC_Web.Models.Base;

namespace TCC_Web.Models.Car
{
    public class Car : BaseModel
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
    }
}
