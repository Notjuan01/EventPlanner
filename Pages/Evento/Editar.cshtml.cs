using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EventPlanner.Pages.Evento
{
    public class EditarModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public EditarModel(EventPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Evento1 Evento1 { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Evento == null)
            {
                return NotFound();
            }

            var evento = await _context.Evento.FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }
            Evento1 = evento;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Evento1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(Evento1.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EventExists(int id)
        {
            return (_context.Evento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
