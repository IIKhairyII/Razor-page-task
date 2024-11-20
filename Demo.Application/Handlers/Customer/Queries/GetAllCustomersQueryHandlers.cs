using Demo.Application.DTOs.Customer.Requests;
using Demo.Application.DTOs.Customer.Responses;
using Demo.Application.Services;
using MediatR;

namespace Demo.Application.Handlers.Customer.Queries
{
    public class GetAllCustomersQueryHandlers : IRequestHandler<GetCustomersDto, ICollection<CustomerDto>>
    {
        private readonly ICustomerService _customerService;
        public GetAllCustomersQueryHandlers(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<ICollection<CustomerDto>> Handle(GetCustomersDto request, CancellationToken cancellationToken)
        {
            return await _customerService.GetAllCustomers();
        }
    }
}
