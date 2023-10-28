using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracking.Data.Models
{
    public class Report
    {
        [Column("ReportId")]
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public int WorkedHours { get; set; }
        public DateOnly Date { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
