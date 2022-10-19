using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ProductWebApi.Models;

namespace ProductWebApi
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> dbContextOptions) : base(dbContextOptions)
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    //creates database if it cannot connect, meaning the datyabase does not exist
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    //creates table if it does not exist
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public DbSet<Product> Products { get; set; }
    }
}
