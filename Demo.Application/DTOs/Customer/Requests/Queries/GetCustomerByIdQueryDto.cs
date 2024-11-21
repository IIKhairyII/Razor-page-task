using Demo.Application.DTOs.Customer.Responses;
using MediatR;

namespace Demo.Application.DTOs.Customer.Requests.Queries
{
    public class GetCustomerByIdQueryDto : IRequest<CustomerDto>
    {
        public int Id { get; set; }
    }
}
