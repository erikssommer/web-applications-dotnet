using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using web_applications_dotnet.Models;

namespace web_applications_dotnet.DAL
{
    public static class DbInit
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<CustomerContext>();

            if (context == null) return;
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var postOffice1 = new PostOffices { Postnr = "0260", PostOffice = "Oslo" };
            var postOffice2 = new PostOffices { Postnr = "1370", PostOffice = "Asker" };

            var customer1 = new Customers
                { FirstName = "Ole", LastName = "Hansen", Address = "Osloveien 82", PostOffice = postOffice1 };
            var customer2 = new Customers
            {
                FirstName = "Line", LastName = "Jensen", Address = "Askerveien 72", PostOffice = postOffice2
            };

            context.Customers.Add(customer1);
            context.Customers.Add(customer2);

            // Make a user from start
            var user = new Users
            {
                Username = "Admin"
            };
            const string password = "Test12";
            var salt = CustomerRepository.GenerateSalt();
            var hash = CustomerRepository.GenerateHash(password, salt);
            user.Password = hash;
            user.Salt = salt;
            context.Users.Add(user);

            context.SaveChanges();
        }
    }
}