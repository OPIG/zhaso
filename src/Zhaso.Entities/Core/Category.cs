using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zhaso.Entities
{
    public class Category : TreeEntity<Category>
    {
        [Column(Order = 11)]
        [Required]
        [MaxLength(50)]
        public string GroupName { set; get; }
        [Column(Order = 12)]
        [Required]
        [MaxLength(50)]
        public string Name { set; get; }
        [Column(Order = 13)]
        [MaxLength(500)]
        public string Description { set; get; }
    }
}
