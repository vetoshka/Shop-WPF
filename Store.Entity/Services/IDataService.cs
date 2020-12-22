using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Domain.Services
{
    public interface IDataService<T>
    {
        Task<T> Insert(T entity);
        Task<T> Update(Guid id, T entity);
        Task<T> Get(Guid id);
        Task<bool> Delete(Guid id);
        IEnumerable<T> GetAll();
    }
}
