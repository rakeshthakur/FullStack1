using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineExamSystem.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
       
        public string UserEmail { get; set; }
        [Required]
        public string UserName { get; set; }
       
        public virtual ICollection<TestDetails> TestDetails { get; set; }
    }
}