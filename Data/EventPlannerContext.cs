using Microsoft.EntityFrameworkCore;
using EventPlanner.Models;


namespace EventPlanner.Data
{
    public class EventPlannerContext : DbContext
    {
        public EventPlannerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Evento1> Evento { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Recurso> Recursos { get; set; }
        public DbSet<Registro> Registros { get; set; }
        public DbSet<Ubicaciones> Ubicacion { get; set; }
        public DbSet<User> Users { get; set; }

    }
}