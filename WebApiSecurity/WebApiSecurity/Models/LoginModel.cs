using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSecurity.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string BirthDate{ get; set; }
    }
}
