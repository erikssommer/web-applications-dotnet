using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using web_applications_dotnet.Models;

namespace web_applications_dotnet.DAL
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _db;
        private readonly ILogger<CustomerRepository> _log;

        public CustomerRepository(CustomerContext db, ILogger<CustomerRepository> log)
        {
            _db = db;
            _log = log;
        }

        public async Task<bool> Save(Customer customer)
        {
            try
            {
                var newCustomerRow = new Customers
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address = customer.Address
                };

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
                var allCustomers = await _db.Customers.Select(k => new Customer
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
                var customer = await _db.Customers.FindAsync(id);
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
                var customer = await _db.Customers.FindAsync(id);
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

        public async Task<bool> LogIn(User user)
        {
            try
            {
                var dbUser = await _db.Users.FirstOrDefaultAsync(b => b.Username == user.Username);
                // sjekk passordet
                var hash = GenerateHash(user.Password, dbUser.Salt);
                var ok = hash.SequenceEqual(dbUser.Password);
                return ok;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }
        }
        
        public static byte[] GenerateHash(string password, byte[] salt)
        {
            return KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 1000,
                numBytesRequested: 32);
        }

        public static byte[] GenerateSalt()
        {
            var csp = new RNGCryptoServiceProvider();
            var salt = new byte[24];
            csp.GetBytes(salt);
            return salt;
        }
    }
}