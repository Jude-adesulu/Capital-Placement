using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Core.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> Exist(Guid id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);
        Task<bool> GetAnyAsync(Expression<Func<T, bool>> expression);
        Task<T> UpdateAsync(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
    }
}
