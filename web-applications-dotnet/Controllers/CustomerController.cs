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
        private readonly CustomerContext _db;

        public CustomerController(CustomerContext db)
        {
            _db = db;
        }

        public async Task<bool> Save(Customer customer)
        {
            try
            {
                var newCustomerRow = new Customers();
                newCustomerRow.FirstName = customer.FirstName;
                newCustomerRow.LastName = newCustomerRow.LastName;
                newCustomerRow.Address = newCustomerRow.Address;

                var testPostnr = await _db.PostOffices.FindAsync(customer.Postnr);
                if (testPostnr == null)
                {
                    var postOfficeRow = new PostOffices();
                    postOfficeRow.Postnr = customer.Postnr;
                    postOfficeRow.PostOffice = customer.PostOffice;
                    newCustomerRow.PostOffice = postOfficeRow;
                }
                else
                {
                    newCustomerRow.PostOffice = testPostnr;
                }

                _db.Customers.Add(newCustomerRow);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Customer>> GetAll()
        {
            try
            {
                List<Customer> allCustomers = await _db.Customers.Select(k => new Customer
                {
                    Id = k.Id,
                    FirstName = k.FirstName,
                    LastName = k.LastName,
                    Address = k.Address,
                    Postnr = k.PostOffice.Postnr,
                    PostOffice = k.PostOffice.PostOffice
                }).ToListAsync();
                return allCustomers;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Customer> GetOne(int id)
        {
            try
            {
                Customers customer = await _db.Customers.FindAsync(id);
                var dbCustomer = new Customer()
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address = customer.Address,
                    Postnr = customer.PostOffice.Postnr,
                    PostOffice = customer.PostOffice.PostOffice
                };
                return dbCustomer;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Customers customer = await _db.Customers.FindAsync(id);
                _db.Customers.Remove(customer);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Customer customer)
        {
            try
            {
                var updateObject = await _db.Customers.FindAsync(customer.Id);
                if (updateObject.PostOffice.Postnr != customer.Postnr)
                {
                    var testPostnr = _db.PostOffices.Find(customer.Postnr);
                    if (testPostnr == null)
                    {
                        var postOfficeRow = new PostOffices();
                        postOfficeRow.Postnr = customer.Postnr;
                        postOfficeRow.PostOffice = customer.PostOffice;
                        updateObject.PostOffice = postOfficeRow;
                    }
                    else
                    {
                        updateObject.PostOffice.Postnr = customer.Postnr;
                    }
                }
                updateObject.FirstName = customer.FirstName;
                updateObject.LastName = customer.LastName;
                updateObject.Address = customer.Address;
                await _db.SaveChangesAsync();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}