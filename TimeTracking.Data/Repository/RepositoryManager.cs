using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Data.Repository.Interfaces;

namespace TimeTracking.Data.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _db;

        private readonly IUserRepository _userRepository;

        private readonly IReportRepository _reportRepository;
        public RepositoryManager(ApplicationDbContext db)
        {
            _db = db;
            _userRepository = new UserRepository(db);
            _reportRepository = new ReportRepository(db);
        }

        public IUserRepository User => _userRepository;
        public IReportRepository Report => _reportRepository;

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
