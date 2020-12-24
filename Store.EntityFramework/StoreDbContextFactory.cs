using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Store.EntityFramework
{
    public class StoreDbContextFactory : IDesignTimeDbContextFactory<StoreDbContext>
    {
        public StoreDbContext CreateDbContext(string[] args = null!)
        {
            DbContextOptionsBuilder<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>();
            options.UseLazyLoadingProxies()
                 .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=StoreDatadb;Trusted_Connection=True;");
            return new StoreDbContext(options.Options);
        }
    }
}
