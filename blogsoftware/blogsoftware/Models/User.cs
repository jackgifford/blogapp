using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blogsoftware.Models
{
    public class User
    {
        [Key]
        [Index(IsUnique = true)]       
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public virtual List<Post> Posts { get; set; }
    }
}