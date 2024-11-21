using Demo.Application.DTOs.Customer.Requests.Commands;
using Demo.Application.Services;
using MediatR;

namespace Demo.Application.Handlers.Customer.Commands
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommandDto, int>
    {
        private readonly ICustomerService _customerService;
        public DeleteCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<int> Handle(DeleteCustomerCommandDto request, CancellationToken cancellationToken)
        {
            try
            {
                return await _customerService.DeleteCustomer(request.Id);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
