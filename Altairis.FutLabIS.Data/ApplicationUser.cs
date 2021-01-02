using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Altairis.FutLabIS.Data
{
    public class ApplicationUser : IdentityUser<int>
    {
        public bool Enabled { get; set; } = true;
        [Required, MinLength(2), MaxLength(2)]
        public string Language { get; set; }
    }
}
