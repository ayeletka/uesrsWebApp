using System.Collections.Generic;
using System.Threading.Tasks;
using myWebApp.Models;

namespace myWebApp.Controllers
{
    public interface IUsersRepository
    {
        Task AddUser(User user);

        Task<List<string>> GetUsers();
    }
}
