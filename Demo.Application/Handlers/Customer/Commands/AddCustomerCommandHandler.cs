using Demo.Application.DTOs.Customer.Requests.Commands;
using Demo.Application.Services;
using MediatR;

namespace Demo.Application.Handlers.Customer.Commands
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommandDto, int>
    {
        private readonly ICustomerService _customerService;
        public AddCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<int> Handle(AddCustomerCommandDto request, CancellationToken cancellationToken)
        {
            try
            {
                return await _customerService.AddCustomer(request);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
