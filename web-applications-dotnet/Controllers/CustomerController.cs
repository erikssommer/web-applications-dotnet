using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using web_applications_dotnet.Models;

namespace web_applications_dotnet.Controllers
{
    [Route("[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        public List<Customer> GetAll()
        {
            var customers = new List<Customer>();
            var customer1 = new Customer();
            customer1.Name = "Per Hansen";
            customer1.Address = "Osloveien 82";

            var customer2 = new Customer
            {
                Name = "Line Hansen",
                Address = "Askerveien 32"
            };
            
            customers.Add(customer1);
            customers.Add(customer2);

            return customers;
        }
    }
}