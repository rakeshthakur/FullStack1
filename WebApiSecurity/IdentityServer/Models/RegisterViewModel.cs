using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HexIdentityServer.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage ="the {0} must be atlleast {2} and max {1} char long.", MinimumLength =6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage ="The passwords don't match.")]
        public string ConfirmPassword { get; set; }

        public ApplicationUser User { get; set; }
    }
}
