using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Review
    {
        public string AuthorName { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }
}