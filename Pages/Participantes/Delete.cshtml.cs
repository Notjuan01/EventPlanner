using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlanner.Pages.Participantes
{
    public class DeleteModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public DeleteModel(EventPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Participante Participantes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Participantes == null)
            {
                return NotFound();
            }

            var participante = await _context.Participantes.FirstOrDefaultAsync(m => m.ID == id);

            if (participante == null)
            {
                return NotFound();
            }
            else
            {
                Participantes = participante;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Participantes == null)
            {
                return NotFound();
            }

            var participante = await _context.Participantes.FindAsync(id);

            if (participante != null)
            {
                participante = participante;
                _context.Participantes.Remove(participante);
                await _context.SaveChangesAsync();
            }



            return RedirectToPage("./Index");
        }
    }
}
