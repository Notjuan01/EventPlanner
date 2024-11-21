using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using EventPlanner.Models;

namespace EventPlanner.Models
{
    public class Participante
    {
    public int ID { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public int Telefono { get; set; }
    }
}
