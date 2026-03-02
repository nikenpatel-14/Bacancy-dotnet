using System.ComponentModel.DataAnnotations;

namespace AssignmeentWebApi.DTOs
{
    public class ProductDTO
    {
        [Required]
        [MaxLength(70)]
        public string Name { get; set; }

        [Range(1000,10000)]
        public int Price { get; set; }

        [Required]
        public string Category { get; set; } 
    }
}
