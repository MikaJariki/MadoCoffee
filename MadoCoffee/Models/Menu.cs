using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MadoCoffee.Models
{
    [Table("Menu")]
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        [Required]
        public int Status { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }

        public ICollection<DishMenuMapping> DishMenuMappings { get; set; }
    }
}
