using System.ComponentModel.DataAnnotations;

namespace Book.Models
{
    public class BookRequest
    {
        [Required]
        public string Name { get; set; }
        public string Type { get; set; }
        [Required]
        public string ISBN { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; } = 0;
        [Required]
        public int Qty { get; set; } = 0;
        [Required] 
        public int Pages { get; set; } = 0;
        public string Language { get; set; }
        public DateTime? Published { get; set; }
        public List<string> Authors { get; set; }
        public string Image { get; set; }
        public Int64 Rating { get; set; }
    }
}
