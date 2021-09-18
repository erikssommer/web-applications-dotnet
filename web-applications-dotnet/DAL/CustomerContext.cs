using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace web_applications_dotnet.Models
{
    public class CustomerContext : DbContext
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