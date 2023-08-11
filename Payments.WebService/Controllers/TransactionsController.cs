using Microsoft.AspNetCore.Mvc;
using Payments.Db;
using Payments.Model.Models;

namespace Payments.WebService.Controllers;

[Route("[controller]")]
[ApiController]
public class TransactionsController : ControllerBase
{
    private readonly PaymentsManager _paymentsManager;

    public TransactionsController(PaymentsManager paymentsManager)
    {
        _paymentsManager = paymentsManager;
    }

    [HttpGet]
    [Route("{userId}")]
    public ActionResult<Transaction[]> GetTransactionsByUserId(int userId)
    {
        return Ok(_paymentsManager.GetTransactionsByUserId(userId));
    }

    [HttpPost]
    [Route("createTransaction")]
    public async Task<ActionResult<Transaction>> CreateTransaction(Transaction transaction)
    {
        transaction = await _paymentsManager.CreateTransaction(transaction);
        return Ok(transaction);
    }
}