using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracking.Data.DTOs;
using TimeTracking.Services.Interfaces;

namespace TimeTracking.API.Controllers
{
    [Route("api/users/{userId}/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ReportsController(IServiceManager serviceManager)
        {
            _service = serviceManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetReportsForUser(Guid userId, [FromQuery] int? monthNumber)
        {
            var reports = await _service.ReportService.GetReportsAsync(userId, monthNumber, false);
            return Ok(reports);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetReportForUser(Guid userId, Guid id)
        {
            var report = await _service.ReportService.GetReportAsync(userId, id, false);
            return Ok(report);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReportForUser
            (Guid userId, [FromBody] ReportCreateAndUpdateDTO report)
        {
            var reportToReturn = await _service.ReportService.CreateReportForUserAsync(userId, report,
                false);

            return CreatedAtAction(nameof(GetReportForUser), new { userId, id = reportToReturn.Id },
                reportToReturn);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteReportForUser(Guid userId, Guid id)
        {
            await _service.ReportService.DeleteReportForUserAsync(userId, id, false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateReportForUser(Guid userId, Guid id,
            [FromBody] ReportCreateAndUpdateDTO report)
        {
            await _service.ReportService.UpdateReportForUserAsync(userId, id, report, true);

            return NoContent();
        }

    }
}
