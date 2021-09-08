using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using web_applications_dotnet.Models;

namespace web_applications_dotnet.Controllers
{
    [Route("[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerContext _db;
        
        public CustomerController(CustomerContext db)
        {
            _db = db;
        }

        public bool Save(Customer customer)
        {
            try
            {
                _db.Customer.Add(customer);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public List<Customer> GetAll()
        {
            try
            {
                return _db.Customer.ToList();
            }
            catch
            {
                return null;
            }
        }

        public Customer GetOne(int id)
        {
            try
            {
                return _db.Customer.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Customer customer = _db.Customer.Find(id);
                _db.Customer.Remove(customer);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Customer customer)
        {
            try
            {
                Customer c = _db.Customer.Find(customer.Id);
                c.Name = customer.Name;
                c.Address = customer.Address;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}