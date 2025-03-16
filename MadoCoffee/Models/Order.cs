using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MadoCoffee.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime BookingTime { get; set; }

        public long? BillID { get; set; }
        public long? TableID { get; set; }
        public long? CustomerID { get; set; }

        [Required]
        public int Status { get; set; }

        public TimeSpan? TimeStampStart { get; set; }
        public TimeSpan? TimeStampEnd { get; set; }

        [Required]
        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        [ForeignKey("CustomerID")]
        public Customer? Customer { get; set; }

        [ForeignKey("CreatedBy")]
        public Employee CreatedByEmployee { get; set; }

        [ForeignKey("UpdatedBy")]
        public Employee? UpdatedByEmployee { get; set; }

        [ForeignKey("BillID")]
        public Bill? Bill { get; set; }

        [ForeignKey("TableID")]
        public Table? Table { get; set; }

        public ICollection<OrderDishMapping> OrderDishMappings { get; set; }
    }
}
