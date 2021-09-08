using Microsoft.EntityFrameworkCore;

namespace web_applications_dotnet.Models
{
    public class CustomerDB : DbContext
    {
        public CustomerDB (DbContextOptions<CustomerDB> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Customer> Customer { get; set; }
    }
}