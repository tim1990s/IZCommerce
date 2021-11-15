using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IZCommerce.Core.Models
{
    public class Category
    {
        [Column("CategoryId")]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string Picture { get; set; }
        
        public bool Active { get; set; }
        
        public ICollection<Product> Products { get; set; }
    }
}
