using System.Collections.Generic;
using System.Threading.Tasks;
using web_applications_dotnet.Models;

namespace web_applications_dotnet.DAL
{
    public interface ICustomerRepository
    {
        Task<bool> Save(Customer customer);
        Task<List<Customer>> GetAll();
        Task<bool> Delete(int id);
        Task<Customer> GetOne(int id);
        Task<bool> Update(Customer customer);
        Task<bool> LogIn(User user);
    }
}