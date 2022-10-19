using CustomerWebAPi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CustomerWebAPi
{
    public class CustomerDbContext : DbContext
    {

        public CustomerDbContext(DbContextOptions<CustomerDbContext> dbContextOptions) : base(dbContextOptions)
        {
			try
			{
				var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
				if(databaseCreator != null)
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

		public DbSet<Customer> Customers { get; set; }
    }
}
