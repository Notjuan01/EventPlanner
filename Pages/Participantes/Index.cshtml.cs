using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.AspNetCore.Authorization;

namespace EventPlanner.Pages.Participantes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public IndexModel(EventPlannerContext context)
        {
            _context = context;
        }

        public IList<Participante> Participantes { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Participantes != null)
            {
                Participantes = await _context.Participantes.ToListAsync();
            }
        }
    }
}
