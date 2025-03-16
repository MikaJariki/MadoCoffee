using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MadoCoffee.Models
{
    [Table("SupplierIngredientMapping")]
    public class SupplierIngredientMapping
    {
        [Required]
        public long SupID { get; set; }

        [Required]
        public long IngID { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        [Required]
        public int Quantity { get; set; }

        [ForeignKey("SupID")]
        public Supplier Supplier { get; set; }

        [ForeignKey("IngID")]
        public Ingredient Ingredient { get; set; }
    }
}
