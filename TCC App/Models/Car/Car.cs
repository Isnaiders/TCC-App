using TCC_App.Models.Base;

namespace TCC_App.Models.Car
{
    public class Car : BaseModel
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
    }
}