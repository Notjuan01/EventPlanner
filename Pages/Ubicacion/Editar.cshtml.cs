using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EventPlanner.Pages.Ubicacion
{
    public class EditarModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public EditarModel(EventPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ubicaciones Ubicacion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ubicacion == null)
            {
                return NotFound();
            }

            var ubicacion = await _context.Ubicacion.FirstOrDefaultAsync(m => m.Id == id);
            if (ubicacion == null)
            {
                return NotFound();
            }
            Ubicacion = ubicacion;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Ubicacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UbicacionExists(Ubicacion.Id))
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

        private bool UbicacionExists(int id)
        {
            return (_context.Ubicacion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
