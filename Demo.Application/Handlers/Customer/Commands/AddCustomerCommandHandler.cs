using Demo.Application.DTOs.Customer.Requests;
using Demo.Application.Services;
using MediatR;

namespace Demo.Application.Handlers.Customer.Commands
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerDto, int>
    {
        private readonly ICustomerService _customerService;
        public AddCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<int> Handle(AddCustomerDto request, CancellationToken cancellationToken)
        {
            return await _customerService.AddCustomer(request);
        }
    }
}
