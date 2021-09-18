using System.Collections.Generic;
using System.Threading.Tasks;

namespace web_applications_dotnet.Models
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