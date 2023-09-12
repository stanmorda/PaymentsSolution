using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace AuthCookies.AuthHandlers;

public class AgeReq : IAuthorizationRequirement
{
    protected internal int Age { get; set; }
    public AgeReq(int age) => Age = age;
}