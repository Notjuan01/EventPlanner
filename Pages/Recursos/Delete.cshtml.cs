using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlanner.Pages.Recursos
{
    public class DeleteModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public DeleteModel(EventPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Recurso Recursos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Recursos == null)
            {
                return NotFound();
            }

            var recurso = await _context.Recursos.FirstOrDefaultAsync(m => m.Id == id);

            if (recurso == null)
            {
                return NotFound();
            }
            else
            {
                Recursos = recurso;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Recursos == null)
            {
                return NotFound();
            }

            var recurso = await _context.Recursos.FindAsync(id);

            if (recurso != null)
            {
                recurso = recurso;
                _context.Recursos.Remove(recurso);
                await _context.SaveChangesAsync();
            }



            return RedirectToPage("./Index");
        }
    }
}
