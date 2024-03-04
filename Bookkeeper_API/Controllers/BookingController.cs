using Bookkeeper_API.Data;
using Bookkeeper_API.Data.DTOs;
using Bookkeeper_API.Model;
using Bookkeeper_API.Model.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookkeeper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IDataRepository _dataRepository;

        public BookingController(ILogger<BookingController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dataRepository = new EFCoreDataRepository(dbContext);
        }

        [HttpPost]
        public IActionResult Book(BookingDto request)
        {
            BookingRecord record = BookingRecordConverter.BookingDtoToBookingRecord(request, _dataRepository);

            // The validation of the booking request happens at processing.
            // Only then will it known if the booking is possible.

            BookingQueue.GetInstance().Enqueue(record);

            return Ok("Your booking requests has been submitted.");
        }
    }
}
