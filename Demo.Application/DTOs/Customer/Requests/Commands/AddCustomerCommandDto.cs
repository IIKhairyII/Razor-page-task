using MediatR;

namespace Demo.Application.DTOs.Customer.Requests.Commands
{
    public class AddCustomerCommandDto : IRequest<int>
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
    }
}
