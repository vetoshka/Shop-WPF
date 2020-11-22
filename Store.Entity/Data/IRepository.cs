using System;
using System.Collections.Generic;

namespace Store.Domain.Data
{
    public interface IRepository<T>
    {
        public void Insert(T entity);
        public void Update(T entity);
        public T GetById(Guid id);
        public void Delete(T entity);
        public IEnumerable<T> GetAll();
    }
}
