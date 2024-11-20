using Demo.Application.DTOs.Customer.Requests;
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
        public async Task<int> AddCustomer(AddCustomerDto customer)
        {
            var newCustomer = new Customer()
            {
                Name = customer.Name,
                BirthDate = customer.BirthDate,
                IsActive = customer.IsActive,
            };
            await _customerRepo.AddAsync(newCustomer);
            return await _customerRepo.SaveCahngesAsync();
        }

        public async Task<int> DeleteCustomer(int id)
        {
            var customer = await _customerRepo.GetByIdAsync(id);
            if (customer is null)
                return 0;
            _customerRepo.Delete(customer);
            return await _customerRepo.SaveCahngesAsync();
        }

        public async Task<ICollection<CustomerDto>> GetAllCustomers()
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

        public async Task<CustomerDto> GetCustomerById(int id)
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
        private int CalculateAge(DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
                age -= 1;
            return age;
        }
    }
}
