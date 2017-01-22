using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace blogsoftware.Models
{
    public class User
    {
        [Key]
        public int UserdID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}