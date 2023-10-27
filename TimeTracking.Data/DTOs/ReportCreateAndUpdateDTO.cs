using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracking.Data.DTOs
{
    public record ReportCreateAndUpdateDTO(string Description, int WorkedHours, DateOnly Date);
}
