using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamSystem.Models
{
    public class UserAnswerDetails
    {
        public int UADId { get; set; }
        public int AnswerId { get; set; }
        
        public int QuestionId { get; set; }

        public int TestId { get; set; }

        
        public virtual TestDetails TestDetails { get; set; }
       // public virtual Question Question { get; set; }

       


    }
}