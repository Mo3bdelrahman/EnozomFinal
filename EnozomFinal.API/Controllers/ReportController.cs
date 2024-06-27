using EnozomFinal.Application.Contracts.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnozomFinal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("bookCopies", Name = "GetAllBookCopies")]
        public async Task<IActionResult> Get() 
        {
            var res = await _reportService.GetAllCopies();
            return Ok(res);
        }
    }
}
