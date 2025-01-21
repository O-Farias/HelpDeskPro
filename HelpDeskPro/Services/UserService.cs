using HelpDeskPro.Models;
using HelpDeskPro.Repositories;

namespace HelpDeskPro.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
            return user;
        }

        public async Task UpdateUserAsync(int id, User updatedUser)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }

            existingUser.Name = updatedUser.Name;
            existingUser.Email = updatedUser.Email;
            existingUser.Password = updatedUser.Password;
            existingUser.Role = updatedUser.Role;

            await _userRepository.UpdateAsync(existingUser);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}
