namespace MaViCS.Domain.Framework.Configuration
{
    public class AuthSettings
    {

        public string Salt { get; set; }
        public AuthType AuthType { get; set; }
        public TokenSettings TokenSettings { get; set; }

    }
}
