using Demo.Application.DTOs.Customer.Requests.Commands;
using Demo.Application.DTOs.Customer.Requests.Queries;
using Demo.Application.DTOs.Customer.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Presentation.Pages.Customer
{
    public class EditModel : PageModel
    {
        private readonly IMediator _mediator;
        [BindProperty]
        public CustomerDto? Customer { get; set; }
        public EditModel(IMediator mediator)
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

            var customer = new UpdateCustomerCommandDto()
            {
                Customer = new()
                {
                    Id = Customer.Id,
                    Name = Customer.Name,
                    IsActive = Customer.IsActive,
                    BirthDate = Customer.BirthDate,
                }
            };
            var result = await _mediator.Send(customer);
            if (result > 0)
                return RedirectToPage("/Customer/Customers");

            ModelState.AddModelError(string.Empty, "Error while editing customer....Make sure customer exists and try again please!!!!");
            return Page();

        }
    }
}
