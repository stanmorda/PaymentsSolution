using System.Security.Claims;
using AuthCookies.Roles;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthCookies.Controllers;


[ApiController]
[Route("[controller]")]
public class DataController : ControllerBase
{
    //4. можем получать данные с токеном
    [Authorize]
    [HttpGet("private")]
    public string GetPrivateData()
    {
        var user = HttpContext.User;
        if (user.Identity != null && user.Identity.IsAuthenticated)
        {
            var identity = (ClaimsIdentity)user.Identity;
            var role = identity.FindFirst(ClaimsIdentity.DefaultRoleClaimType);
            if (role != null)
            {
                return role.Value;
            }
        }

        return "NON ROLE";
    }

    [HttpGet("age")]
    [Authorize(Roles = "ADMIN,USER", Policy = "AgeLimit")]
    public string CheckAgeHandler()
    {
        return "success"; 
    }
    
    [HttpGet("admin")]
    [Authorize(Roles = "ADMIN,USER")]
    public string Admin()
    {
        return "success";
    }
    
    [HttpGet("public")]
    public string GetPublicData()
    {
        var user = HttpContext.User;
        if (user.Identity != null && user.Identity.IsAuthenticated)
        {
            var company = user.FindFirst(ClaimTypes.Country);
            
        }
        return "Not Auth";
    }

    [HttpGet("addCountry")]
    public async Task AddCountryForUser(string country)
    {
        var user = HttpContext.User;
        if (user.Identity != null && user.Identity.IsAuthenticated)
        {
            var identity = (ClaimsIdentity)user.Identity;
            identity.AddClaim(new Claim(ClaimTypes.Country, country));
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);
        }
    }
}