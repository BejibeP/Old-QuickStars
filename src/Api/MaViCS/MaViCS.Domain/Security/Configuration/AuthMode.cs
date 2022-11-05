namespace QuickStars.MaViCS.Domain.Security.Configuration
{
    public class AuthMode
    {

        public string Name { get; set; }

        public static AuthMode JWT { get { return new AuthMode() { Name = "JWT" }; } }
        public static AuthMode IS4 { get { return new AuthMode() { Name = "IS4" }; } }

    }
}
