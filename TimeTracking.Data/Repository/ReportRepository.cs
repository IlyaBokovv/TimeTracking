using Microsoft.EntityFrameworkCore;
using TimeTracking.Data.Models;
using TimeTracking.Data.Repository.Interfaces;

namespace TimeTracking.Data.Repository
{
    public class ReportRepository : RepositoryBase<Report>, IReportRepository
    {
        public readonly ApplicationDbContext _db;

        public ReportRepository(ApplicationDbContext db)
            : base(db)
        {
            _db = db;
        }

        public void CreateReportForUser(Guid userId, Report report)
        {
            report.UserId = userId;
            Create(report);
        }

        public void DeleteReport(Report report)
        {
            Delete(report);
        }

        public async Task<Report> GetReportAsync(Guid userId, Guid id, bool trackChanges)
        {
            return await FindByCondition(r => r.UserId == userId && r.Id == id, trackChanges).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Report>> GetReportsAsync(Guid userId, int? monthNumber, bool trackChanges)
        {
            var query = FindByCondition(r => r.UserId == userId, trackChanges);
            if(monthNumber > 0)
            {
                query = FindByCondition(r => r.UserId == userId, trackChanges).
                    Where(r => r.Date.Month == monthNumber);
            }
            return await query.ToListAsync();
        }
    }
}
