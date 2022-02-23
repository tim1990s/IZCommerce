using AutoMapper;
using IZCommerce.Application.Contracts.Persistence;
using IZCommerce.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IZCommerce.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommandResponse>
    {
        private readonly IAsyncRepository<Order> _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IMapper mapper, IAsyncRepository<Order> orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var createOrderCommandResponse = new CreateOrderCommandResponse();
            var validator = new CreateOrderCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            //Error

            if (!validatorResult.IsValid) // Or validatorResult.Errors.Count>0
            {
                createOrderCommandResponse.Success = false;
                createOrderCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validatorResult.Errors)
                {
                    createOrderCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            // Success

            if (createOrderCommandResponse.Success)
            {
                var order = new Order()
                {
                    OrderNumber = request.OrderNumber,
                    OrderDate = request.OrderDate,
                    CustomerId = request.CustomerId,
                    PaymentId = request.PaymentId,
                    ShipperId = request.ShipperId
                };

                order = await _orderRepository.AddAsync(order);
                createOrderCommandResponse.Order = _mapper.Map<CreateOrderDto>(order);
            }

            return createOrderCommandResponse;
        }
    }
}
