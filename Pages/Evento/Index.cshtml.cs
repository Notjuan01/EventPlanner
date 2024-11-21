using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventPlanner.Data;
using EventPlanner.Models;

namespace EventPlanner.Pages.Eventos
{
    public class IndexModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public IndexModel(EventPlannerContext context)
        {
            _context = context;
        }

        public IList<Evento1> Evento { get; set; } = default!;

        public async Task OnGetAsync()
        {   
            if (_context.Evento != null)
            {
                Evento = await _context.Evento.ToListAsync();
            }
        }
    }
}
