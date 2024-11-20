using Demo.Application.Repositories;
using Demo.Domain.Entities;
using Demo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);


        public void Delete(T entity)
        {
            if (entity != null)
                _context.Set<T>().Remove(entity);

        }
        public async Task<ICollection<T>> GetAll() => await _context.Set<T>().ToListAsync();


        public async Task<T?> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);


        public async Task<int> SaveCahngesAsync() => await _context.SaveChangesAsync();


        public void Update(T entity) => _context.Set<T>().Update(entity);

    }
}
