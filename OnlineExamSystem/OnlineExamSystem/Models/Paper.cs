using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamSystem.Models
{
    public class Paper
    {
        public int PaperId { get; set; }
        public string PaperName { get; set; }
        public virtual ICollection<TestDetails> TestDetails { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}