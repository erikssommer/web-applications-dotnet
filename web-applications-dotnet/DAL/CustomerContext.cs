using Microsoft.EntityFrameworkCore;
using web_applications_dotnet.Models;

namespace web_applications_dotnet.DAL
{
    public sealed class CustomerContext : DbContext
    {
        public CustomerContext (DbContextOptions<CustomerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<PostOffices> PostOffices { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}