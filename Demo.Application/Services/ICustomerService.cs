using Demo.Application.DTOs.Customer.Requests;
using Demo.Application.DTOs.Customer.Responses;

namespace Demo.Application.Services
{
    public interface ICustomerService
    {
        Task<ICollection<CustomerDto>> GetAllCustomers();
        Task<CustomerDto> GetCustomerById(int id);
        Task<int> DeleteCustomer(int id);
        Task<int> AddCustomer(AddCustomerDto customer);
    }
}
