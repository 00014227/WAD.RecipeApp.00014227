using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeBook.Repositories
{
    public interface IRepository_00014227 <T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIDAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
