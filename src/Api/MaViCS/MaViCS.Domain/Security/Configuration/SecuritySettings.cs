namespace QuickStars.MaViCS.Domain.Security.Configuration
{
    public class SecuritySettings
    {

        public string Salt { get; set; }
        public AuthMode Mode { get; set; }
        public JWTSettings JWT { get; set; }

    }
}
