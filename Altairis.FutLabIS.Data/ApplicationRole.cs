using Microsoft.AspNetCore.Identity;

namespace Altairis.FutLabIS.Data
{
    public class ApplicationRole : IdentityRole<int>
    {
        public const string Member = "Member";
        public const string Master = "Master";
        public const string Administrator = "Administrator";
    }
}
