namespace AuthCookies.Roles;

public class Role
{
    public string Name { get; set; }
    public Role(string name) => Name = name;
}

public static class RolesNames
{
    public static string Admin = "ADMIN";
    public static string User = "USER";
    
}