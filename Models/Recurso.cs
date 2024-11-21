using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using EventPlanner.Models;

namespace EventPlanner.Models
{
    public class Recurso
    {
    public int Id { get; set; }
    public int IdEvento { get; set; }
    public string NombreRecurso { get; set; }
    public int Cantidad { get; set; }
    public string Decripcion { get; set; }

    }
}
