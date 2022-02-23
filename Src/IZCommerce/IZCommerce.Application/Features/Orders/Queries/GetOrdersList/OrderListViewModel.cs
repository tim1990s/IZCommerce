using System;

namespace IZCommerce.Application.Features.Orders.Queries.GetOrdersList
{
    public class OrderListViewModel
    {
        public int OrderId { get; set; }

        public string OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }

        public int PaymentId { get; set; }

        public int ShipperId { get; set; }

    }
}
