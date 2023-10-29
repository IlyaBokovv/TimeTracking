using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Data.Models;
using TimeTracking.Data.Repository.Interfaces;

namespace TimeTracking.Data.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
            : base(db)
        {
            _db = db;
        }

        public void CreateUser(User user)
        {
            Create(user);
        }

        public void DeleteUser(User user)
        {
            Delete(user);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(u => u.LastName).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            return await FindByCondition(x => ids.Contains(x.Id), trackChanges).ToListAsync();
        }

        public async Task<User> GetUserAsync(Guid userId, bool trackChanges)
        {
            return await FindByCondition(x => x.Id == userId, trackChanges).FirstOrDefaultAsync();
        }
        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return !await _db.Set<User>().AnyAsync(u => u.Email == email);
        }
    }
}
