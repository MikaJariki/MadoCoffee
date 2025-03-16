using System.ComponentModel.DataAnnotations;

namespace MadoCoffee.DTO
{
    public class CustomerDto
    {
        public long ID { get; set; }
        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(10)]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone number must be 10 characters.")]
        public string PhoneNo { get; set; }

        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        public int? Gender { get; set; }

        [MaxLength(255)]
        public string Note { get; set; }
    }
}
