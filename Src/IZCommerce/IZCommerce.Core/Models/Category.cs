using System.Collections.Generic;

namespace IZCommerce.Core.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public bool Active { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
