using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracking.Services.Interfaces
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
        IReportService ReportService { get; }
    }
}
