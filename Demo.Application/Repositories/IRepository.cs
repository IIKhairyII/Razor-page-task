using Demo.Domain.Entities;

namespace Demo.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<ICollection<T>> GetAll();
        Task<T?> GetByIdAsync(int id);
        Task<int> AddAsync(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);

    }
}
