using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace AuthCookies.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginTestController : ControllerBase
{
    //3. генерируем токен
    
    [HttpGet]
    public async Task Login(string userName)
    {

        var claims = new List<Claim> { new Claim(ClaimTypes.Name, userName) };
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
        
        // установка аутентификационных куки
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
            new ClaimsPrincipal(claimsIdentity));
        
    }
}