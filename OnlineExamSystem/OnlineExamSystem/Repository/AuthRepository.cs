using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineExamSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OnlineExamSystem.Repository
{
    public class AuthRepository
    {
        private AuthContext _ctx;
        private UserManager<IdentityUser> _userManager;
        public AuthRepository()
        {
            _ctx = new AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }
        public async Task<IdentityResult> RegisterUser(Admin userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.AdminEmail
            };
            var result = await _userManager.CreateAsync(user, userModel.AdminPassword);
            return result;
        }
        public async System.Threading.Tasks.Task<IdentityUser> FindUser(string email, string pwd)
        {
            var result = await _userManager.FindAsync(email, pwd);
            return result;
        }
    }
}