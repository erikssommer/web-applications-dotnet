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

        private ILogger<CustomerController> _log;

        public CustomerController(ICustomerRepository db, ILogger<CustomerController> log)
        {
            _db = db;
            _log = log;
        }
        
        public async Task<ActionResult> Save(Customer customer)
        {
            bool ret = await _db.Save(customer);

            if (!ret)
            {
                _log.LogInformation("Customer was not saved");
                return BadRequest("Customer was not saved");
            }

            return Ok("Customer saved");
            
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

            return Ok("Customer found");
        }

        public async Task<ActionResult> Update(Customer customer)
        {
            bool ret = await _db.Update(customer);

            if (!ret)
            {
                _log.LogInformation("Customer was not found");
                return NotFound("Customer was not found");
            }

            return Ok("Customer updated");
        }
    }
}