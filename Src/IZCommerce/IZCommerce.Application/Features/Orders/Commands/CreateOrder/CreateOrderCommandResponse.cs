using IZCommerce.Application.Responses;

namespace IZCommerce.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandResponse : BaseResponse
    {
        public CreateOrderCommandResponse() : base()
        {
        }

        public CreateOrderDto Order { get; set; }
    }
}