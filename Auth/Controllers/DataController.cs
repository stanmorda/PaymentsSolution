using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers;


[ApiController]
[Route("[controller]")]
public class DataController : ControllerBase
{
    //4. можем получать данные с токеном
    [Authorize]
    [HttpGet("private")]
    public string GetPrivateData()
    {
        return "PrivateData";
    }
    
    [HttpGet("public")]
    public string GetPublicData()
    {
        return "PublicData";
    }
}