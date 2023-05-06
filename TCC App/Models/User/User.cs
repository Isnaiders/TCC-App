using TCC_App.Models.Base;

namespace TCC_App.Models.User
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}