using TimeTracking.Data.Models;

namespace TimeTracking.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges);
        Task<User> GetUserAsync(Guid userId, bool trackChanges);
        void CreateUser(User user);
        void DeleteUser(User user);
        Task<bool> IsEmailUniqueAsync(string email);
    }
}
