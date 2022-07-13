using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Models
{
    public class User
    {
        [Key]
        public int Uid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
