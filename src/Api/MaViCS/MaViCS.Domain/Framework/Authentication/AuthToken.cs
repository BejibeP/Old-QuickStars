namespace MaViCS.Domain.Framework.Authentication
{
    public class AuthToken
    {

        public string Username { get; set; }

        public string Token { get; set; }

        public AuthToken(string username, string token)
        {
            Username = username;
            Token = token;
        }

    }
}
