using Archive.CDManagement.Api.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Archive.CDManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;

        public ReportController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        [HttpGet("cdrentalcount/{id}")]
        public IActionResult GetCdRentalCount(int id)
        {
            return Ok(_reportRepository.SingleCDCount(id));
        }

        [HttpGet("allcdrentalcount")]
        public IActionResult GetAllCdRentalCount()
        {
            return Ok(_reportRepository.AllCDCount());
        }
    }
}