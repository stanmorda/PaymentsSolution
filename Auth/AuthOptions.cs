using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Auth;

public class AuthOptions
{
    public const string Issuer = "Issuer123";
    public const string Audience = "Audience123";
    
    public const string SecretKey = "mysupersecret_secretkey!123";
    
    public static SymmetricSecurityKey GetSymmetricSecurityKey() => 
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
}