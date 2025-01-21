using HelpDeskPro.Models;

namespace HelpDeskPro.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User> CreateUserAsync(User user);
        Task UpdateUserAsync(int id, User updatedUser);
        Task DeleteUserAsync(int id);
    }
}
