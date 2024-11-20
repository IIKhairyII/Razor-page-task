using Demo.Domain.Entities;

namespace Demo.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<ICollection<T>> GetAll();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> SaveCahngesAsync();

    }
}
