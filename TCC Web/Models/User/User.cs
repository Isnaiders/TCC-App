using TCC_Web.Models.Base;

namespace TCC_Web.Models.User
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string LicenseDrive { get; set; }
    }
}
