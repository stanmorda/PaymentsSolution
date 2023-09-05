using Microsoft.AspNetCore.Mvc;
using Payments.Db;
using Payments.Db.Services;
using Payments.Model.Models;

namespace Payments.WebService.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IPaymentsManager _paymentsManager;

    public UsersController(IPaymentsManager paymentsManager)
    {
        _paymentsManager = paymentsManager;
    }

    [HttpGet]
    [Route("getUsers")]
    public ActionResult<User[]> GetUsers()
    {
        return Ok(_paymentsManager.GetUsers());
    }

    [HttpPost]
    [Route("createUser")]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        user = await _paymentsManager.CreateUser(user);
        return Ok(user);
    }
}