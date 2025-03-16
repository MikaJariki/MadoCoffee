using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MadoCoffee.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string FullName { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string PhoneNo { get; set; }

        [Column(TypeName = "varchar(50)")]
        [EmailAddress]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Address { get; set; }
        public int? Gender { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Note { get; set; }
        public ICollection<Bill>? Bills { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
