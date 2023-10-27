using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Data.DTOs;
using TimeTracking.Data.Models;
using TimeTracking.Data.Repository;
using TimeTracking.Data.Repository.Interfaces;
using TimeTracking.Services.Interfaces;

namespace TimeTracking.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public UserService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDTO> CreateUserAsync(UserCreateAndUpdateDTO user)
        {
            var userEntity = _mapper.Map<User>(user);
            _repository.User.CreateUser(userEntity);
            await _repository.SaveChangesAsync();

            var userToReturn = _mapper.Map<UserDTO>(user);
            return userToReturn;
        }

        public async Task DeleteUserAsync(Guid userId, bool trackChanges)
        {
            var user = await _repository.User.GetUserAsync(userId, trackChanges);
            if (user is null)
            {
                //throw new UserNotFoundException(id);
            }
            _repository.User.DeleteUser(user);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync(bool trackChanges)
        {
            var users = await _repository.User.GetAllUsersAsync(trackChanges);

            var usersDTO = _mapper.Map<IEnumerable<UserDTO>>(users);
            return usersDTO;
        }

        public async Task<UserDTO> GetUserAsync(Guid userId, bool trackChanges)
        {
            var user = await _repository.User.GetUserAsync(userId, trackChanges);
            if(user is null)
            {
                //throw new UserNotFoundException(id);
            }
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;

        }

        public async Task UpdateUserAsync(Guid userId, UserCreateAndUpdateDTO userForUpdate, bool trackChanges)
        {
            var user = await _repository.User.GetUserAsync(userId,trackChanges);
            if(user is null)
            {
                //throw new UserNotFoundException(id);
            }
            _mapper.Map(userForUpdate, user);
            await _repository.SaveChangesAsync();
        }
    }
}
