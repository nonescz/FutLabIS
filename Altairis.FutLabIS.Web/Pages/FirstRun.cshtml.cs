using Altairis.FutLabIS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Altairis.FutLabIS.Web.Pages
{
    public class FirstRunModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;

        public FirstRunModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager ?? throw new System.ArgumentNullException(nameof(userManager));
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public class InputModel
        {
            [Required, MaxLength(50)]
            public string UserName { get; set; }

            [Required, MaxLength(50), EmailAddress]
            public string EmailAddress { get; set; }

            [Required, DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public IActionResult OnGet()
        {
            if (this.userManager.Users.Any()) return this.NotFound();
            this.Input.Password = SecurityHelper.GenerateRandomPassword();
            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            if (this.userManager.Users.Any()) return this.NotFound();
            if (!this.ModelState.IsValid) return this.Page();

            // Create user
            var user = new ApplicationUser
            {
                UserName = this.Input.UserName,
                Email = this.Input.EmailAddress,
                EmailConfirmed = true,
                Language = "cs"
            };

            if (!this.IsIdentitySuccess(await this.userManager.CreateAsync(user, this.Input.Password))) return this.Page();

            // Assign Administrator role
            if (!this.IsIdentitySuccess(await userManager.AddToRoleAsync(user, ApplicationRole.Administrator))) return this.Page();

            // Redirect to homepage
            return this.RedirectToPage("Index");
        }
    }
}
