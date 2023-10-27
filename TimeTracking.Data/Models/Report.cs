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
        [Required(ErrorMessage = "Description is a required field")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Worked hours is a required field")]
        public int WorkedHours { get; set; }
        [Required(ErrorMessage = "Current date is a required field")]
        public DateOnly CurrentDate { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
