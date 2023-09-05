using Microsoft.AspNetCore.Mvc;
using Payments.Db;
using Payments.Model.Models;

namespace Payments.WebService.Controllers;

[Route("[controller]")]
[ApiController]
public class TransactionsController : ControllerBase
{
    private readonly DbPaymentsManager _dbPaymentsManager;

    public TransactionsController(DbPaymentsManager dbPaymentsManager)
    {
        _dbPaymentsManager = dbPaymentsManager;
    }

    [HttpGet]
    [Route("{userId}")]
    public ActionResult<Transaction[]> GetTransactionsByUserId(int userId)
    {
        return Ok(_dbPaymentsManager.GetTransactionsByUserId(userId));
    }

    [HttpPost]
    [Route("createTransaction")]
    public async Task<ActionResult<Transaction>> CreateTransaction(Transaction transaction)
    {
        transaction = await _dbPaymentsManager.CreateTransaction(transaction);
        return Ok(transaction);
    }
}