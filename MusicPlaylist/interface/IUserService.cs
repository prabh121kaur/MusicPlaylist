using CoreEntityFramework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreEntityFramework.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
