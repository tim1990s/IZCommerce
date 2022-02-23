using IZCommerce.Domain.Common;
using System;

namespace IZCommerce.Domain.Entities
{

    public class OrderDetail : TrackingEntity
    {
        public int orderDetailId { get; set; }

        public int OrderNumber { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public double Discount { get; set; }

        public double Total { get; set; }

        public string IDSKU { get; set; }

        public int Size { get; set; }

        public string Color { get; set; }

        public string Fullfilled { get; set; }

        public DateTime dateTime { get; set; }

        public DateTime BillDate { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
