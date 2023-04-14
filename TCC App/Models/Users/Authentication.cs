using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_App.Models.Users
{
    public class Authentication
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
