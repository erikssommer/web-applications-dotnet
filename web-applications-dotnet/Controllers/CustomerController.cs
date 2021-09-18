using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using web_applications_dotnet.Models;

namespace web_applications_dotnet.Controllers
{
    [Route("[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _db;

        private readonly ILogger<CustomerController> _log;

        public CustomerController(ICustomerRepository db, ILogger<CustomerController> log)
        {
            _db = db;
            _log = log;
        }
        
        public async Task<ActionResult> Save(Customer customer)
        {
            if (ModelState.IsValid)
            {
                bool ret = await _db.Save(customer);

                if (!ret)
                {
                    _log.LogInformation("Customer was not saved");
                    return BadRequest("Customer was not saved");
                }

                return Ok("Customer saved");
            }
            _log.LogInformation("Input validation failed");
            return BadRequest("Input validation failed");

        }

        public async Task<ActionResult> GetAll()
        {
            List<Customer> list = await _db.GetAll();
            return Ok(list);
        }

        public async Task<ActionResult> Delete(int id)
        {
            bool ret = await _db.Delete(id);

            if (!ret)
            {
                _log.LogInformation("Customer was not deleted");
                return NotFound("Customer was not deleted");
            }

            return Ok("Customer deleted");
        }

        public async Task<ActionResult> GetOne(int id)
        {
            Customer customer = await _db.GetOne(id);

            if (customer == null)
            {
                _log.LogInformation("Customer was not found");
                return NotFound("Customer was not found");
            }

            return Ok(customer);
        }

        public async Task<ActionResult> Update(Customer customer)
        {
            if (ModelState.IsValid)
            {
                bool ret = await _db.Update(customer);

                if (!ret)
                {
                    _log.LogInformation("Customer was not found");
                    return NotFound("Customer was not found");
                }

                return Ok("Customer updated");
            }
            _log.LogInformation("Input validation failed");
            return BadRequest("Input validation failed");
        }
        
        public async Task<ActionResult> LogIn(User user) 
        {
            if (ModelState.IsValid)
            {
                bool ret = await _db.LogIn(user);
                if (!ret)
                {
                    _log.LogInformation("Log in failed for user: "+user.Username);
                    return Ok(false);
                }
                return Ok(true);
            }
            _log.LogInformation("Input validation failed");
            return BadRequest("Input validation failed on server");
        }
    }
}