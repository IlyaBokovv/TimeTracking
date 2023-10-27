using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Data.DTOs;
using TimeTracking.Data.Exceptions;
using TimeTracking.Data.Models;
using TimeTracking.Data.Repository.Interfaces;
using TimeTracking.Services.Interfaces;

namespace TimeTracking.Services
{
    public class ReportService : IReportService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ReportService(IRepositoryManager repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ReportDTO> CreateReportForUserAsync(Guid userId, ReportCreateAndUpdateDTO report, bool trackChanges)
        {
            var user = await _repository.User.GetUserAsync(userId, trackChanges);
            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }
            var reportEntity = _mapper.Map<Report>(report);

            _repository.Report.CreateReportForUser(userId, reportEntity);
            await _repository.SaveChangesAsync();

            var reportToReturn = _mapper.Map<ReportDTO>(reportEntity);
            return reportToReturn;

        }

        public async Task DeleteReportForUserAsync(Guid userId, Guid id, bool trackChanges)
        {
            var user = await _repository.User.GetUserAsync(userId, trackChanges);
            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }
            var reportEntity = await _repository.Report.GetReportAsync(userId, id, trackChanges);
            if (reportEntity is null)
            {
                throw new ReportNotFoundException(id);
            }
            _repository.Report.DeleteReport(reportEntity);
            await _repository.SaveChangesAsync();
        }

        public async Task<ReportDTO> GetReportAsync(Guid userId, Guid id, bool trackChanges)
        {
            var user = await _repository.User.GetUserAsync(userId, trackChanges);
            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }
            var reportEntity = await _repository.Report.GetReportAsync(userId, id, trackChanges);
            if (reportEntity is null)
            {
                throw new ReportNotFoundException(id);
            }
            var report = _mapper.Map<ReportDTO>(reportEntity);
            return report;
        }

        public async Task<IEnumerable<ReportDTO>> GetReportsAsync(Guid userId, bool trackChanges)
        {
            var user = await _repository.User.GetUserAsync(userId, trackChanges);
            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }
            var reportsEntity = await _repository.Report.GetReportsAsync(userId, trackChanges);
            var reports = _mapper.Map<IEnumerable<ReportDTO>>(reportsEntity);
            return reports;
        }

        public async Task UpdateReportForUserAsync(Guid userId, Guid id, ReportCreateAndUpdateDTO reportForUpdate, bool trackChanges)
        {
            var user = await _repository.User.GetUserAsync(userId, trackChanges);
            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }
            var reportEntity = await _repository.Report.GetReportAsync(userId, id, trackChanges);
            if (reportEntity is null)
            {
                throw new ReportNotFoundException(id);
            }
            _mapper.Map(reportForUpdate, reportEntity);
            await _repository.SaveChangesAsync();
        }
    }
}
