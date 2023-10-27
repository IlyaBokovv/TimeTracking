using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Data.DTOs;

namespace TimeTracking.Services.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<ReportDTO>> GetReportsAsync(Guid userId, bool trackChanges);
        Task<ReportDTO> GetReportAsync(Guid userId, Guid id, bool trackChanges);
        Task<ReportDTO> CreateReportForUserAsync(Guid userId,
            ReportCreateAndUpdateDTO report, bool trackChanges);
        Task DeleteReportForUserAsync(Guid userId, Guid id, bool trackChanges);
        Task UpdateReportForUserAsync(Guid userId, Guid id, ReportCreateAndUpdateDTO reportForUpdate, bool trackChanges);
    }
}
