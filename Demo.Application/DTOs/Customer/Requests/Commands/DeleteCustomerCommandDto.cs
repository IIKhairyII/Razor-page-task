using MediatR;

namespace Demo.Application.DTOs.Customer.Requests.Commands
{
    public class DeleteCustomerCommandDto : IRequest<int>
    {
        public int Id { get; set; }
    }
}
