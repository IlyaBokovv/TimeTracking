using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Data.Repository.Interfaces;
using TimeTracking.Services.Interfaces;

namespace TimeTracking.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IUserService _userService;
        private readonly IReportService _reportService;
        public ServiceManager(IRepositoryManager manager, IMapper mapper)
        {
            _userService = new UserService(manager, mapper);
            _reportService = new ReportService(manager, mapper);
        }
        public IUserService UserService => _userService;

        public IReportService ReportService => _reportService;
    }
}
