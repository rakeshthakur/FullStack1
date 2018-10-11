using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineExamSystem.Models
{
    public class TestDetails
    {
        public int TestId { get; set; }
        public string UserEmail { get; set; }
        public int Marks { get; set; }
        public virtual User user { get; set; }
        public int PaperId { get; set; }
        
        public DateTime TestDate { get; set; }
        public virtual Paper Paper { get; set; }
        public virtual ICollection<UserAnswerDetails> UserAnswers { get; set; }
    }
}