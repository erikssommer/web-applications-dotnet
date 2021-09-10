using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace web_applications_dotnet.Models
{
    public class Customers
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public PostOffices PostOffice { get; set; }
    }

    public class PostOffices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Postnr { get; set; }
        public String PostOffice { get; set; }
        
        virtual public List<Customers> Customers { get; set; }
    }
    public class CustomerContext : DbContext
    {
        public CustomerContext (DbContextOptions<CustomerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<PostOffices> PostOffices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}