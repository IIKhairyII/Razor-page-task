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
        public async Task<int> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return await _context.SaveChangesAsync();
        }


        public async Task<int> Delete(T entity)
        {
            if (entity != null)
                _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }
        public async Task<ICollection<T>> GetAll() => await _context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int id)
        {
            var e = await _context.Set<T>()?.FirstOrDefaultAsync(a => a.Id == id)!;
            if (e != null) return e;
            else return default!;
        }
        public async Task<int> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync();
        }

    }
}
