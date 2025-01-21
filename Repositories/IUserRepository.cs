using HelpDeskPro.Models;

namespace HelpDeskPro.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}
