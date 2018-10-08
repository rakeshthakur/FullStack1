using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCViews.Models
{
    public class Blog
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Email { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
