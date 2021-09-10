using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace web_applications_dotnet.Models
{
    public static class DBInit
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CustomerContext>();

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var postOffice1 = new PostOffices { Postnr = "0270", PostOffice = "Oslo" };
                var postOffice2 = new PostOffices { Postnr = "1370", PostOffice = "Asker" };

                var customer1 = new Customers
                    { FirstName = "Ole", LastName = "Hansen", Address = "Osloveien 82", PostOffice = postOffice1 };
                var customer2 = new Customers
                    { FirstName = "Line", LastName = "Jensen", Address = "Askerveien 72", PostOffice = postOffice2 };

                context.Customers.Add(customer1);
                context.Customers.Add(customer2);

                context.SaveChanges();
            }
        }
    }
}