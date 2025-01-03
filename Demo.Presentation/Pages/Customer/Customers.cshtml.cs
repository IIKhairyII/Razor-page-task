using Demo.Application.DTOs.Customer.Requests.Queries;
using Demo.Application.DTOs.Customer.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Presentation.Pages.Customer
{
    public class CustomersModel : PageModel
    {
        private readonly IMediator _mediator;
        public List<CustomerDto> Customers { get; set; }
        public CustomersModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task OnGet()
        {
            var customers = await _mediator.Send(new GetCustomersQueryDto());
            Customers = customers.ToList();
        }
    }
}
