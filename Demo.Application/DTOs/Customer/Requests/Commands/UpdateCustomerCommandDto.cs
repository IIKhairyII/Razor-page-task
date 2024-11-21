using Demo.Application.DTOs.Customer.Responses;
using MediatR;

namespace Demo.Application.DTOs.Customer.Requests.Commands
{
    public class UpdateCustomerCommandDto : IRequest<int>
    {
        public CustomerDto Customer { get; set; }
    }
}
