using IZCommerce.Application.Features.Orders.Commands.CreateOrder;
using MediatR;
using System;

namespace IZCommerce.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderCommandResponse>
    {

        public string OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }

        public int PaymentId { get; set; }

        public int ShipperId { get; set; }
    }
}
