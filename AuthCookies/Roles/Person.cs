namespace AuthCookies.Roles;

public class Person
{
    public string  Email { get; set; }
    public string  Password { get; set; }
    public Role Role { get; set; }
    public byte Age { get; set; }

    public Person(string email, string password, Role role, byte age)
    {
        Email = email;
        Password = password;
        Role = role;
        Age = age;
    }
}