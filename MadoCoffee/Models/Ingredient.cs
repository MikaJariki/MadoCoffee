using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MadoCoffee.Models
{
    [Table("Ingredient")]
    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public long UnitID { get; set; }

        [ForeignKey("UnitID")]
        public Unit Unit { get; set; }

        public ICollection<SupplierIngredientMapping> SupplierIngredientMappings { get; set; }
    }
}
