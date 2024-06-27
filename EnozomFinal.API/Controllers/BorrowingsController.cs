using EnozomFinal.Application.Contracts.IServices;
using EnozomFinal.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace EnozomFinal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class BorrowingsController : ControllerBase
    {
        private readonly IBorrowingService _borrowingService;

        public BorrowingsController(IBorrowingService borrowingService)
        {
            _borrowingService = borrowingService;
        }

        [HttpPost("students/{StudentId}/copies/{CopyId}", Name = "AddBorrowing")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddBorrowing(int StudentId, int CopyId,[FromBody] DateTime date)
        {
            BorrowDto borrowDto = new BorrowDto { StudentId = StudentId, CopyId = CopyId , ExpectedReturnDate = date};
            string message =  await _borrowingService.BorrowBookCopy(borrowDto);
            return Ok(message);
        }

        [HttpPost("{BorrowingId}/status/{StatusId}", Name = "ReturnBorrowing")]
        public async Task<IActionResult> ReturnBorrowing(int BorrowingId, int StatusId)
        {
            ReturnDto returnDto = new ReturnDto { BorrowingId = BorrowingId , StatusId = StatusId};
            string message = await _borrowingService.ReturnBookCopy(returnDto);
            return Ok(message);
        }


    }
}
