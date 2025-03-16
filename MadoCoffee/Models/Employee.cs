using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MadoCoffee.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        [Column(TypeName = "varchar(10)")]
        public string PhoneNo { get; set; }

        [EmailAddress]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string? Email { get; set; }

        public int? Gender { get; set; }

        [Required]
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string Address { get; set; }

        [Required]
        public long RoleID { get; set; }

        [ForeignKey("RoleID")]
        public Role Role { get; set; }

        [Required]
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string Password { get; set; }

        [Required]
        public int Status { get; set; }

        public ICollection<EmployeeShiftMapping> EmployeeShiftMappings { get; set; }
    }
}
