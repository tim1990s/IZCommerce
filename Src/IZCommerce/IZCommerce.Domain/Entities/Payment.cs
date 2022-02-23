using IZCommerce.Domain.Common;
using System.Collections.Generic;

namespace IZCommerce.Domain.Entities
{
    public class Payment : TrackingEntity
    {
        public int paymentId { get; set; }

        public int PaymentType { get; set; }

        public bool Allowed { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
