using System.ComponentModel.DataAnnotations.Schema;

namespace blogsoftware.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}