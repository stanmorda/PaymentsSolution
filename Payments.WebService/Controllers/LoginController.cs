using Microsoft.AspNetCore.Mvc;

namespace Payments.WebService.Controllers;

/// <summary>
/// 4. Login method logic for clients
/// </summary>
[Route("[controller]")]
[ApiController]

public class LoginController : ControllerBase
{
    private readonly SessionStore _sessionStore;

    public LoginController(SessionStore sessionStore)
    {
        _sessionStore = sessionStore;
    }

    [HttpPost("login")]
    public string Login(LoginData data)
    {
        return _sessionStore.Login(data.Login, data.Password);
    }

    public class LoginData
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}