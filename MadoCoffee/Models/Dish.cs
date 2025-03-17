using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace MadoCoffee.Models
{
    [Table("Dish")]
    public class Dish
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string? Description { get; set; }

        [JsonIgnore]
        public string? ImageUrl { get; set; }

        [JsonIgnore]
        public ICollection<DishMenuMapping>? DishMenuMappings { get; set; }

        [JsonIgnore]
        public ICollection<OrderDishMapping>? OrderDishMappings { get; set; }
    }
}
