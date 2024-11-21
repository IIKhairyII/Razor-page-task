using Demo.Application.DTOs.Customer.Requests.Queries;
using Demo.Application.DTOs.Customer.Responses;
using Demo.Application.Services;
using MediatR;

namespace Demo.Application.Handlers.Customer.Queries
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQueryDto, CustomerDto>
    {
        private readonly ICustomerService _customerService;
        public GetCustomerByIdQueryHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<CustomerDto> Handle(GetCustomerByIdQueryDto request, CancellationToken cancellationToken)
        {
            return await _customerService.GetCustomerById(request.Id);
        }
    }
}
