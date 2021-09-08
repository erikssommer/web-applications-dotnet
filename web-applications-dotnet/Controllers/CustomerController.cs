using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using web_applications_dotnet.Models;

namespace web_applications_dotnet.Controllers
{
    [Route("[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDB _customerDb;

        public CustomerController(CustomerDB customerDb)
        {
            _customerDb = customerDb;
        }
        public List<Customer> GetAll()
        {
            List<Customer> customers = _customerDb.Customer.ToList();
            return customers;
        }
    }
}