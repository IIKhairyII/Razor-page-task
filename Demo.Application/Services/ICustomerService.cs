using Demo.Application.DTOs.Customer.Requests.Commands;
using Demo.Application.DTOs.Customer.Responses;

namespace Demo.Application.Services
{
    public interface ICustomerService
    {
        Task<ICollection<CustomerDto>> GetAllCustomers();
        Task<CustomerDto> GetCustomerById(int id);
        Task<int> DeleteCustomer(int id);
        Task<int> AddCustomer(AddCustomerCommandDto customer);
        Task<int> EditCustomer(UpdateCustomerCommandDto customer);
    }
}
