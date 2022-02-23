using IZCommerce.Domain.Common;
using System;

namespace IZCommerce.Domain.Entities
{
    public class Order : TrackingEntity
    {
        public int OrderId { get; set; }

        public string OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int PaymentId { get; set; }

        public Payment Payment { get; set; }

        public int ShipperId { get; set; }

        public Shipper Shipper { get; set; }
    }
}
