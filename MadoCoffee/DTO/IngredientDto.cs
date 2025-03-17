using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MadoCoffee.Models;

namespace MadoCoffee.DTO
{
    public class IngredientDto
    {
        public long ID { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
        public int Quantity { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        [Required]  
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public decimal Price { get; set; }
        
        [Required]
        public long UnitID { get; set; }
    }
}