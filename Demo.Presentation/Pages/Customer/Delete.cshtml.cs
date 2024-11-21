using Demo.Application.DTOs.Customer.Requests.Commands;
using Demo.Application.DTOs.Customer.Requests.Queries;
using Demo.Application.DTOs.Customer.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Presentation.Pages.Customer
{
    public class DeleteModel : PageModel
    {
        private readonly IMediator _mediator;
        [BindProperty]
        public CustomerDto Customer { get; set; }
        public DeleteModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task OnGet(int id)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQueryDto() { Id = id });
            Customer = customer;
        }
        public async Task<IActionResult> OnPost()
        {
            var result = await _mediator.Send(new DeleteCustomerCommandDto() { Id = Customer.Id });
            if (result > 0)
                return RedirectToPage("/Customer/Customers");

            ModelState.AddModelError(string.Empty, "Error while deleting customer....Make sure customer exists and try again please!!!!");
            return Page();
        }
    }
}
