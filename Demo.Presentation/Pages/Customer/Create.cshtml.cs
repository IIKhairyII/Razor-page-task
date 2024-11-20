using Demo.Application.DTOs.Customer.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Presentation.Pages.Customer
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        [BindProperty]
        public AddCustomerDto Customer { get; set; }

        private readonly IMediator _mediator;
        public CreateModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public void OnGet()
        {
        }
        public async Task OnPost()
        {
            await _mediator.Send(Customer);
        }
    }
}
