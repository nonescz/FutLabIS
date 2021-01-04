namespace Altairis.FutLabIS.Web
{
    public class AppSettings
    {
        public SecurityConfig Security { get; set; } = new SecurityConfig();

        public class SecurityConfig
        {
            public int MinimumPasswordLength { get; set; } = 12;
            public int DefaultPasswordLength { get; set; } = 14;
            public int LoginCookieExpirationDays { get; set; } = 30;
        }
    }
}
