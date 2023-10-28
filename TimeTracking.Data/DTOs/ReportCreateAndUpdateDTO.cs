using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracking.Data.DTOs
{
    public record ReportCreateAndUpdateDTO()
    {
        public string? Description { get; set; }
        public int? WorkedHours { get; set; }
        public DateOnly? Date { get; set; }
    }
}
