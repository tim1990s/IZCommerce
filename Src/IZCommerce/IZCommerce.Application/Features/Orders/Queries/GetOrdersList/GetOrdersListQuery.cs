using MediatR;
using System.Collections.Generic;

namespace IZCommerce.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQuery : IRequest<List<OrderListViewModel>>
    {
    }
}
