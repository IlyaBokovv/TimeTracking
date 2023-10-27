using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracking.Data.Models;

public class User
{
    [Column("UserId")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Email address is a required field")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "First name is a required field")]
    public string? FirstName { get; set; }
    [Required(ErrorMessage = "Middle name is a required field")]
    public string? MiddleName { get; set; }
    [Required(ErrorMessage = "Last name is a required field")]
    public string? LastName { get; set; }
    public ICollection<Report>? Reports { get; set; }
}
