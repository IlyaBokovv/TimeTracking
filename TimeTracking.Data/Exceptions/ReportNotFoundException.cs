using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracking.Data.Exceptions
{
    public class ReportNotFoundException : NotFoundException
    {
        public ReportNotFoundException(Guid id)
            : base($"Report with id: {id} doesn`t exist in the database")
        {
        }
    }
}
