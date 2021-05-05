namespace ApplicationCore.Settings
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public int JwtTokenLifetimeInSeconds { get; set; }
    }
}