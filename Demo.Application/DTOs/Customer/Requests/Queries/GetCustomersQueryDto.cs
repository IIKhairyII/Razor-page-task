using Demo.Application.DTOs.Customer.Responses;
using MediatR;

namespace Demo.Application.DTOs.Customer.Requests.Queries
{
    public class GetCustomersQueryDto : IRequest<ICollection<CustomerDto>>
    {
    }
}
