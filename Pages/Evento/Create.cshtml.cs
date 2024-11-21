using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventPlanner.Data;
using EventPlanner.Models;

namespace EventPlanner.Pages.Evento
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
        public Evento1 Evento { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Evento.Add(Evento);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
