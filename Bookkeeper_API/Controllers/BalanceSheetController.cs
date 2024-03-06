using Bookkeeper_API.Data;
using Bookkeeper_API.Data.DTOs;
using Bookkeeper_API.Model;
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
        private readonly IDataRepository _repository;

        public BalanceSheetController(ILogger<BalanceSheetController> logger, AppDbContext context)
        {
            _logger = logger;
            _repository = new EFCoreDataRepository(context);
        }

        [HttpGet]
        public IActionResult GetBalanceSheet()
        {
            BalanceSheetDto dto = new BalanceSheet(_repository).StateBalance();
            return Ok(dto);
        }
    }
}
