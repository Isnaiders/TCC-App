namespace TCC_Web.Models.User
{
    public class Authentication
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
