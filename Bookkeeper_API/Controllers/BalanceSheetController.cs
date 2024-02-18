using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookkeeper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BalanceSheetController : ControllerBase
    {
        private readonly ILogger<BalanceSheetController> _logger;

        public BalanceSheetController(ILogger<BalanceSheetController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetBalanceSheet()
        {
            throw new NotImplementedException();
        }
    }
}
