using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MadoCoffee.Models
{
    [Table("DishMenuMapping")]
    public class DishMenuMapping
    {
        [Key]
        [Column(Order = 1)]
        public long DishID { get; set; }

        [Key]
        [Column(Order = 2)]
        public long MenuID { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }

        [ForeignKey("DishID")]
        public Dish Dish { get; set; }

        [ForeignKey("MenuID")]
        public Menu Menu { get; set; }
    }
}
