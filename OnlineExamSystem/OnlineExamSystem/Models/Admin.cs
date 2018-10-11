using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineExamSystem.Models
{
    public class Admin
    {
        [Required]        
        public string AdminEmail { get; set; }

        [Required, DataType(DataType.Password)]      
        public string AdminPassword { get; set; }

        [Required, DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}