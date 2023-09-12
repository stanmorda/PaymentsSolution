using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AuthCookies.AuthHandlers;

public class AgeAuthHandler : AuthorizationHandler<AgeReq>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext httpContext, AgeReq requirement)
    {
        var yearClaim = httpContext.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth);
        
        if (yearClaim is not null)
        {
            if (byte.TryParse(yearClaim.Value, out var year))
            {
                if (year >= requirement.Age)
                {
                    httpContext.Succeed(requirement); 
                }
            }
        }
        return Task.CompletedTask;
    }
}