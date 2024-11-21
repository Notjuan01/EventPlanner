using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using EventPlanner.Models;

namespace EventPlanner.Models
{
    public class Evento1
    {
        public int Id { get; set; }
        public string EventoName { get; set; }
        public string EventoDescription { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin {  get; set; }
        public int IdUbicacion { get; set; }

    }
}
