using System.Collections.Generic;

namespace IZCommerce.Core.Models
{
    public class Payment
    {
        public int paymentId { get; set; }

        public int PaymentType { get; set; }

        public bool Allowed { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
