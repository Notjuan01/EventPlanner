using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventPlanner.Data;
using EventPlanner.Models;

namespace EventPlanner.Pages.Recursos
{
    public class IndexModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public IndexModel(EventPlannerContext context)
        {
            _context = context;
        }

        public IList<Recurso> Recursos { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Recursos != null)
            {
                Recursos = await _context.Recursos.ToListAsync();
            }
        }
    }
}
