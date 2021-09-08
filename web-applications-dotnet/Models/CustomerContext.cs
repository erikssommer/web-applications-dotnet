using Microsoft.EntityFrameworkCore;

namespace web_applications_dotnet.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext (DbContextOptions<CustomerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Customer> Customer { get; set; }
    }
}