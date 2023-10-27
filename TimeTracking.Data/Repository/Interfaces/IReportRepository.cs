using TimeTracking.Data.Models;

namespace TimeTracking.Data.Repository.Interfaces
{
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> GetReportsAsync(Guid userId, bool trackChanges);
        Task<Report> GetReportAsync(Guid userId, Guid id, bool trackChanges);
        void CreateReportForUser(Guid userId, Report report);
        void DeleteReport(Report report);
    }
}
