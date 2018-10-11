using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamSystem.Models
{
    public class AuthContext:IdentityDbContext
    {
        public AuthContext() : base("name=onexmdbstring") { }
    }
}