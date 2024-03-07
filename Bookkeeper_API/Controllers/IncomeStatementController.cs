using Bookkeeper_API.Data;
using Bookkeeper_API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookkeeper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IncomeStatementController : ControllerBase
    {
        private readonly ILogger<IncomeStatementController> _logger;
        private readonly IDataRepository _dataRepository;

        public IncomeStatementController(ILogger<IncomeStatementController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dataRepository = new EFCoreDataRepository(dbContext);
        }

        [HttpGet]
        public IActionResult GetIncomeStatement()
        {
            try
            {
                IEnumerable<Account> accounts = _dataRepository.GetIncomeStatementAccounts();
                IncomeStatement incomeStatement = new IncomeStatement(_dataRepository);
                return Ok(incomeStatement.StateIncome());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
