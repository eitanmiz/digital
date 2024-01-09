using Microsoft.EntityFrameworkCore;

namespace DigitalServerItems.Models
{
    public class ApiContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ProductsDb");
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<City> Cities { get; set; } = null!;
    }
}
