using System.ComponentModel.DataAnnotations;

namespace ProductApp.App.Models
{
    public class ProductVM
    {
        public int? ID { get; set; } //take note
        [Required]
        [MinLength(3)]
        public string? Stock { get; set; }
        [Required]
        [MinLength(3)]
        public string? Type { get; set; }
        [Required]
        
        public int? Price { get; set; }
        [Required]
        public int? Qty { get; set; }
        [Required]
        public string? Supplier { get; set; }

        public DateTime? DateStocked { get; set; } = DateTime.Now;

    }
}
