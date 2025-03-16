using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MadoCoffee.Models
{
    [Table("OrderDishMapping")]
    public class OrderDishMapping
    {
        [Key, Column(Order = 0)]
        public long OrderID { get; set; }

        [Key, Column(Order = 1)]
        public long DishID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [ForeignKey("OrderID")]
        public Order Order { get; set; }

        [ForeignKey("DishID")]
        public Dish Dish { get; set; }
    }
}
