using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.AspNetCore.Authorization;

namespace EventPlanner.Pages.Registros
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public IndexModel(EventPlannerContext context)
        {
            _context = context;
        }

        public IList<Registro> Registros { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Registros != null)
            {
                Registros = await _context.Registros.ToListAsync();
            }
        }
    }
}
