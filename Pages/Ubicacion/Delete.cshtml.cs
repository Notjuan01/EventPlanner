using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.EntityFrameworkCore;


namespace EventPlanner.Pages.Ubicacion
{
    public class DeleteModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public DeleteModel(EventPlannerContext context)
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
            else
            {
                Ubicacion = ubicacion;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Ubicacion == null)
            {
                return NotFound();
            }

            var ubicacion = await _context.Ubicacion.FindAsync(id);

            if (ubicacion != null)
            {
                ubicacion = ubicacion;
                _context.Ubicacion.Remove(ubicacion);
                await _context.SaveChangesAsync();
            }



            return RedirectToPage("./Index");
        }
    }
}
