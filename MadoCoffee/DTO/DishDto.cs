using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MadoCoffee.DTO
{
    public class DishDto
     
    {   
        public long Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public decimal Price { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IFormFile? Image { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ImageUrl { get; set; }
    }
}
