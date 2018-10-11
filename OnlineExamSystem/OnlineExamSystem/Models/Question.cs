using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineExamSystem.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        //[Required]
        //public String QuestionType { get; set; }
        [Required]
        public String QuestionName { get; set; }

        public int PaperId { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        //public virtual ICollection<UserAnswerDetails> UserAnswerDetails { get; set; }
        public virtual Paper Paper { get; set; }

    }
}