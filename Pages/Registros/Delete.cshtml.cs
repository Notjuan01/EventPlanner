using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlanner.Pages.Registros
{
    public class DeleteModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public DeleteModel(EventPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Registro Registros { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Registros == null)
            {
                return NotFound();
            }

            var registro = await _context.Registros.FirstOrDefaultAsync(m => m.Id == id);

            if (registro == null)
            {
                return NotFound();
            }
            else
            {
                Registros = registro;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Registros == null)
            {
                return NotFound();
            }

            var registro = await _context.Registros.FindAsync(id);

            if (registro != null)
            {
                registro = registro;
                _context.Registros.Remove(registro);
                await _context.SaveChangesAsync();
            }



            return RedirectToPage("./Index");
        }
    }
}
