using Altairis.FutLabIS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Altairis.FutLabIS.Web.Pages.Login
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        public LogoutModel(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }
        public async Task<IActionResult> OnGetAsync(string done = null)
        {
            if (String.IsNullOrEmpty(done))
            {
                await this.signInManager.SignOutAsync();
                return this.RedirectToPage(new { done = "done" });
            }
            return this.Page();
        }
    }
}
