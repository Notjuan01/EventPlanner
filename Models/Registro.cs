using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using EventPlanner.Models;

namespace EventPlanner.Models
{
    public class Registro
    {
     public int Id { get; set; }
     public int IdEvento { get; set; }
     public int IdParticipante { get; set; }
     public DateTime FechaRegistro { get; set; }
    }
}
