using System.Security.Authentication;

namespace Payments.WebService;

public class SessionStore
{

    private Dictionary<string, string> _users;

    private Dictionary<string, string> _sessions = new ();

    /// <summary>
    /// 2. Get users from Db
    /// </summary>
    private void InitUsers()
    {
        _users = new Dictionary<string, string>()
        {
            { "user", "password" },
            { "user1", "password1" },
            { "user2", "password2" },
        };
    }

    /// <summary>
    /// 3. Login
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public string Login(string login, string password)
    {
        if (_users.TryGetValue(login, out var pass))
        {
            if (string.Equals(pass, password))
            {

                var session = new Guid().ToString();
                _sessions[login] = session;
                return session;
            }
        }

        throw new AuthenticationException("Not authorize");
    }
    
}