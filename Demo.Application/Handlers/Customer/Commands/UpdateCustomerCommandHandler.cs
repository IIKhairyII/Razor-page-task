using Demo.Application.DTOs.Customer.Requests.Commands;
using Demo.Application.Services;
using MediatR;

namespace Demo.Application.Handlers.Customer.Commands
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommandDto, int>
    {

        private readonly ICustomerService _customerService;
        public UpdateCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public Task<int> Handle(UpdateCustomerCommandDto request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
