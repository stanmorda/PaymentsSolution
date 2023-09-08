using System.ComponentModel;
using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using TestDIApi.Exstensions;

namespace TestDIApi.Controllers;

/// <summary>
/// 4. Login method logic for clients
/// </summary>

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private readonly SessionStore _sessionStore;
    public static string SessionKey = "MySessionKey";

    public LoginController(SessionStore sessionStore)
    {
        _sessionStore = sessionStore;
    }

    
    [HttpPost("login")]
    public ActionResult Login(LoginData data)
    {
        try
        {
            var session = _sessionStore.Login(data.Login, data.Password);
            if (!HttpContext.Session.Keys.Contains(SessionKey))
            {
                HttpContext.Session.Set(SessionKey, session);
            }

            return Ok();
        }
        catch (AuthenticationException e)
        {
            return Unauthorized(e.Message);
        }
    }

    public class LoginData
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}