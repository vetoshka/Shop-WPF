using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Models;
using Store.Domain.Services;
using Store.EntityFramework;

namespace Store.EntityFramework
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly StoreDbContextFactory _storeDbContextFactory;

        public GenericDataService( StoreDbContextFactory storeDbContextFactory)
        {
            _storeDbContextFactory = storeDbContextFactory;
        }
        public async Task<bool> Delete(Guid id)
        {
            using (StoreDbContext context = _storeDbContextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<T> Get(Guid id)
        {
            using (StoreDbContext context = _storeDbContextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public  IEnumerable<T> GetAll()
        {
            StoreDbContext context = _storeDbContextFactory.CreateDbContext();
            return context.Set<T>();
            
        }

        public async Task<T> Insert(T entity)
        {
            using (StoreDbContext context = _storeDbContextFactory.CreateDbContext())
            {
               var createdEntity= await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return createdEntity.Entity;
            }
        }

        public async Task<T> Update(Guid id, T entity)
        {
            using (StoreDbContext context = _storeDbContextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }
    }
}
