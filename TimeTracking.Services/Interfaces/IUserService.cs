using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Data.DTOs;

namespace TimeTracking.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync(bool trackChanges);
        Task<UserDTO> GetUserAsync(Guid userId, bool trackChanges);
        Task<UserDTO> CreateUserAsync(UserCreateAndUpdateDTO user);
        Task DeleteUserAsync(Guid userId, bool trackChanges);
        Task UpdateUserAsync(Guid userId, UserCreateAndUpdateDTO userForUpdate, bool trackChanges);
    }
}
