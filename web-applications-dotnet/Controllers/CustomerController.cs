using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using web_applications_dotnet.DAL;
using web_applications_dotnet.Models;

namespace web_applications_dotnet.Controllers
{
    [Route("[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _db;

        private readonly ILogger<CustomerController> _log;

        private const string LoggedIn = "logedIn";

        public CustomerController(ICustomerRepository db, ILogger<CustomerController> log)
        {
            _db = db;
            _log = log;
        }
        
        public async Task<ActionResult> Save(Customer customer)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(LoggedIn)))
            {
                return Unauthorized();
            }
            if (ModelState.IsValid)
            {
                var ret = await _db.Save(customer);

                if (ret) return Ok("Customer saved");
                _log.LogInformation("Customer was not saved");
                return BadRequest("Customer was not saved");

            }
            _log.LogInformation("Input validation failed");
            return BadRequest("Input validation failed");

        }

        public async Task<ActionResult> GetAll()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(LoggedIn)))
            {
                return Unauthorized();
            }
            var list = await _db.GetAll();
            return Ok(list);
        }

        public async Task<ActionResult> Delete(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(LoggedIn)))
            {
                return Unauthorized();
            }
            var ret = await _db.Delete(id);

            if (ret) return Ok("Customer deleted");
            _log.LogInformation("Customer was not deleted");
            return NotFound("Customer was not deleted");

        }

        public async Task<ActionResult> GetOne(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(LoggedIn)))
            {
                return Unauthorized();
            }
            var customer = await _db.GetOne(id);

            if (customer != null) return Ok(customer);
            _log.LogInformation("Customer was not found");
            return NotFound("Customer was not found");

        }

        public async Task<ActionResult> Update(Customer customer)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(LoggedIn)))
            {
                return Unauthorized();
            }
            if (ModelState.IsValid)
            {
                var ret = await _db.Update(customer);

                if (ret) return Ok("Customer updated");
                _log.LogInformation("Customer was not found");
                return NotFound("Customer was not found");

            }
            _log.LogInformation("Input validation failed");
            return BadRequest("Input validation failed");
        }
        
        public async Task<ActionResult> LogIn(User user) 
        {
            if (ModelState.IsValid)
            {
                var ret = await _db.LogIn(user);
                if (ret)
                {
                    HttpContext.Session.SetString(LoggedIn, "LoggedIn");
                    return Ok(true);
                }
                _log.LogInformation("Log in failed for user: "+user.Username);
                HttpContext.Session.SetString(LoggedIn, "");
                return Ok(false);
            }
            _log.LogInformation("Input validation failed");
            return BadRequest("Input validation failed on server");
        }

        public void LogOut()
        {
            HttpContext.Session.SetString(LoggedIn, "");
        }
    }
}