namespace MaViCS.Domain.Framework.Configuration
{
    public class AuthType
    {

        public static AuthType JWT { get { return new AuthType() { Name = "JWT" }; } }
        public static AuthType IS4 { get { return new AuthType() { Name = "IS4" }; } }

        public string Name { get; set; }

    }
}
