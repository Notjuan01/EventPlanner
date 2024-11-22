using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventPlanner.Data;
using EventPlanner.Models;

namespace EventPlanner.Pages.Participantes
{
    public class CreateModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public CreateModel(EventPlannerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Participante Participantes { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Participantes.Add(Participantes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
