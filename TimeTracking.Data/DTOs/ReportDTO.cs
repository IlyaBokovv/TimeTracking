using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracking.Data.DTOs
{
    public record ReportDTO(Guid Id, string Description, int WorkedHours, DateOnly Date);
}
