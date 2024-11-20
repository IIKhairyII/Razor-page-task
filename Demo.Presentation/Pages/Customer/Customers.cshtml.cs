using Demo.Application.DTOs.Customer.Requests;
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
            Customers = (await _mediator.Send(new GetCustomersDto())).ToList();
        }
    }
}
