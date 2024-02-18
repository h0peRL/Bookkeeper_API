using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookkeeper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeStatementController : ControllerBase
    {
        private readonly ILogger<IncomeStatementController> _logger;

        public IncomeStatementController(ILogger<IncomeStatementController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetIncomeStatement()
        {
            throw new NotImplementedException();
        }
    }
}
