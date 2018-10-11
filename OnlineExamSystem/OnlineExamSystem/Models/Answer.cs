using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineExamSystem.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        
        public int QuestionId { get; set; }
        [Required]
        public string AnswerName { get; set; }
        
        public bool IsCorrect { get; set; }

        public virtual Question Question { get; set; }

    }
}