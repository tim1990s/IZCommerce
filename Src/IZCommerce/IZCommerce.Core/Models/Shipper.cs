using System.Collections.Generic;

namespace IZCommerce.Core.Models
{
    public class Shipper
    {
        public int ShipperId { get; set; }

        public string CompanyName { get; set; }

        public string Phone { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
