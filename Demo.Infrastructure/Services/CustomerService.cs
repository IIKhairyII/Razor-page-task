using Demo.Application.DTOs.Customer.Requests.Commands;
using Demo.Application.DTOs.Customer.Responses;
using Demo.Application.Repositories;
using Demo.Application.Services;
using Demo.Domain.Entities;

namespace Demo.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;
        public CustomerService(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }
        public async Task<int> AddCustomer(AddCustomerCommandDto customer)
        {
            try
            {
                var newCustomer = new Customer()
                {
                    Name = customer.Name,
                    BirthDate = customer.BirthDate,
                    IsActive = customer.IsActive,
                };
                return await _customerRepo.AddAsync(newCustomer);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> DeleteCustomer(int id)
        {
            try
            {
                var customer = await _customerRepo.GetByIdAsync(id);
                if (customer is null)
                    return 0;
                return await _customerRepo.Delete(customer);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> EditCustomer(UpdateCustomerCommandDto customer)
        {
            try
            {
                if (customer is null)
                    return 0;
                var updatedCustomer = new Customer()
                {
                    Id = customer.Customer.Id,
                    Name = customer.Customer.Name,
                    IsActive = customer.Customer.IsActive,
                    BirthDate = customer.Customer.BirthDate,
                };
                return await _customerRepo.Update(updatedCustomer);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<ICollection<CustomerDto>> GetAllCustomers()
        {

            try
            {
                var customers = await _customerRepo.GetAll();
                return customers.Select(c =>
                {
                    return new CustomerDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        IsActive = c.IsActive,
                        BirthDate = c.BirthDate,
                        Age = CalculateAge(c.BirthDate)
                    };
                }).ToList();
            }
            catch (Exception ex)
            {
                return new List<CustomerDto>();
            }
        }

        public async Task<CustomerDto> GetCustomerById(int id)
        {
            try
            {
                var customer = await _customerRepo.GetByIdAsync(id);
                if (customer is null)
                    return null;
                var result = new CustomerDto
                {
                    BirthDate = customer.BirthDate,
                    Name = customer.Name,
                    IsActive = customer.IsActive,
                    Id = customer.Id,
                    Age = CalculateAge(customer.BirthDate)
                };
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private int CalculateAge(DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
                age -= 1;
            return age;
        }
    }
}
