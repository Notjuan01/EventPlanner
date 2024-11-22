using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.AspNetCore.Authorization;


namespace EventPlanner.Pages.Ubicacion
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public IndexModel(EventPlannerContext context)
        {
            _context = context;
        }

        public IList<Ubicaciones> Ubicacion { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Ubicacion != null)
            {
                Ubicacion = await _context.Ubicacion.ToListAsync();
            }
        }
    }
}
