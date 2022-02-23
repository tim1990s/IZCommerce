using AutoMapper;
using IZCommerce.Application.Contracts.Persistence;
using IZCommerce.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IZCommerce.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrderListViewModel>>
    {
        private readonly IAsyncRepository<Order> _orderRepository;
        private IMapper _mapper;

        public GetOrdersListQueryHandler(IMapper mapper, IAsyncRepository<Order> orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderListViewModel>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var allOrders = (await _orderRepository.ListAllAsync()).OrderBy(o => o.OrderDate);
            return _mapper.Map<List<OrderListViewModel>>(allOrders);
        }
    }
}
