using IZCommerce.Domain.Common;
using System.Collections.Generic;

namespace IZCommerce.Domain.Entities
{
    public class Shipper : TrackingEntity
    {
        public int ShipperId { get; set; }

        public string CompanyName { get; set; }

        public string Phone { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
