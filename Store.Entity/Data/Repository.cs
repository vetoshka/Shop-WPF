using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Store.Domain.Data
{
   public class Repository<T>:IRepository<T> where T: class
    {
        readonly DBContext _context;
        readonly DbSet<T> _dbSet;

        public Repository(DBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public void Insert(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            _context.SaveChanges();

        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public T GetById(Guid id)
        {
            return _dbSet.Find(id);
        }
    }
}
