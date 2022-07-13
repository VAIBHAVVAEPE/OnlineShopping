using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Models
{
    public class Product
    {
        [Key]
        public int PId { get; set; }
        public string Pname { get; set; }
        public int Pprice { get; set; }
        public string Pdescription { get; set; }
    }
    }
