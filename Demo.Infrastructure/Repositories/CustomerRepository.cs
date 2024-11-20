using Demo.Application.Repositories;
using Demo.Domain.Entities;
using Demo.Infrastructure.Context;

namespace Demo.Infrastructure.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
