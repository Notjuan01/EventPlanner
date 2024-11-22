using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using EventPlanner.Models;
using EventPlanner.Data;

namespace EventPlanner.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public LoginModel(EventPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var UsersLogin = _context.Users
                .FirstOrDefault(identityDb => identityDb.Email == User.Email && identityDb.Password == User.Password);

            if (UsersLogin != null)
            {
                var clains = new List<Claim>
                {
                new Claim(ClaimTypes.Name, "admin"),
                new Claim(ClaimTypes.Email, User.Email),
                };
                var identity = new ClaimsIdentity(clains, "MycookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MycookieAuth", claimsPrincipal);
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
