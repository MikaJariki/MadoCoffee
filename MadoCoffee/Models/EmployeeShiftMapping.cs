using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MadoCoffee.Models
{
    [Table("EmployeeShiftMapping")]
    public class EmployeeShiftMapping
    {
        [Key]
        [Column(Order = 1)]
        public long EmpID { get; set; }

        [Key]
        [Column(Order = 2)]
        public long ShiftID { get; set; }

        [Required]
        public DateTime WorkDate { get; set; }

        [ForeignKey("EmpID")]
        public Employee Employee { get; set; }

        [ForeignKey("ShiftID")]
        public Shift Shift { get; set; }
    }
}
