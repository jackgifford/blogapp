using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace blogsoftware.Models
{
    public class Post
    {
        public Guid PostID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}