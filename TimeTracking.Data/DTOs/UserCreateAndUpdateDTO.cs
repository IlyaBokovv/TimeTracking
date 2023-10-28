using System.ComponentModel.DataAnnotations;

namespace TimeTracking.Data.DTOs
{
    public record UserCreateAndUpdateDTO
    {
        public string? Email { get; init; }
        public string? FirstName { get; init; }
        public string? MiddleName { get; init; }
        public string? LastName { get; init; }
        public IEnumerable<ReportCreateAndUpdateDTO>? Reports { get; set; }
    }
}
