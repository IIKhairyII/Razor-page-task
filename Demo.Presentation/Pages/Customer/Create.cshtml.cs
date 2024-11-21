using Demo.Application.DTOs.Customer.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Presentation.Pages.Customer
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        [BindProperty]
        public AddCustomerCommandDto Customer { get; set; }

        private readonly IMediator _mediator;
        public CreateModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var result = await _mediator.Send(Customer);
            if (result > 0)
                return RedirectToPage("/Customer/Customers");
            ModelState.AddModelError(string.Empty, "Error while adding customer....try again please!!!!");
            return Page();
        }
    }
}
