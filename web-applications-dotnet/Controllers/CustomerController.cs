using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_applications_dotnet.Models;

namespace web_applications_dotnet.Controllers
{
    [Route("[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _db;

        public CustomerController(ICustomerRepository db)
        {
            _db = db;
        }
        
        public async Task<bool> Save(Customer customer)
        {
            return await _db.Save(customer);
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _db.GetAll();
        }

        public async Task<bool> Delete(int id)
        {
            return await _db.Delete(id);
        }

        public async Task<Customer> GetOne(int id)
        {
            return await _db.GetOne(id);
        }

        public async Task<bool> Update(Customer customer)
        {
            return await _db.Update(customer);
        }
    }
}