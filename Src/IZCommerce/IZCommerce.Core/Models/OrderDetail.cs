using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IZCommerce.Core.Models
{
    public class OrderDetail
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

        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
