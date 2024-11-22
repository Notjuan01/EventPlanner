using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using EventPlanner.Models;

namespace EventPlanner.Models
{
    public class Ubicaciones
    {
    public int Id { get; set; }
    public string NombreUbicacion { get; set; }
    public int Capacidad { get; set; }
    public string Direccion { get; set; }
    }
}
