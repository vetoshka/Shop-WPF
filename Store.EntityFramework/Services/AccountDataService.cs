using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Models;
using Store.Domain.Services;

namespace Store.EntityFramework.Services
{
  public class AccountDataService :IAccountService
    {
        private readonly StoreDbContextFactory _storeDbContextFactory;

        public AccountDataService(StoreDbContextFactory storeDbContextFactory)
        {
            _storeDbContextFactory = storeDbContextFactory;
        }
        public async Task<bool> Delete(Guid id)
        {
            using (StoreDbContext context = _storeDbContextFactory.CreateDbContext())
            {
                Account entity = await context.Set<Account>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<Account>().Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Account> Get(Guid id)
        {
            using (StoreDbContext context = _storeDbContextFactory.CreateDbContext())
            {
                Account entity = await context.Accounts.FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public IEnumerable<Account> GetAll()
        {
            StoreDbContext context = _storeDbContextFactory.CreateDbContext();
            return context.Set<Account>();

        }

        public async Task<Account> Insert(Account entity)
        {
            using (StoreDbContext context = _storeDbContextFactory.CreateDbContext())
            {
                var createdEntity = await context.Set<Account>().AddAsync(entity);
                await context.SaveChangesAsync();
                return createdEntity.Entity;
            }
        }

        public async Task<Account> Update(Guid id, Account entity)
        {
            using (StoreDbContext context = _storeDbContextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<Account>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<Account> GetByUserName(string username)
        {
            using (StoreDbContext context = _storeDbContextFactory.CreateDbContext())
            {
                return await context.Accounts.FirstOrDefaultAsync((e) => e.AccountHolder.Name == username);
            }
        }

        public async Task<Account> GetByEmail(string email)
        {
            using (StoreDbContext context = _storeDbContextFactory.CreateDbContext())
            {
                 return await context.Accounts.FirstOrDefaultAsync((e) => e.AccountHolder.Email == email);
            }
        }
    }
}
