using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EventPlanner.Models;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventPlanner.Models;


namespace EventPlanner.Data

{
    public class EventPlannerContext : DbContext
    {
    public EventPlannerContext(DbContextOptions options) : base(options) 
    {
    }

     public DbSet<Evento> Events { get; set; }
     public DbSet<Participante> Participantes { get; set; }
     public DbSet<Recurso> Recursos { get; set; }
     public DbSet<Registro> Registros { get; set; }
     public DbSet<Ubicaciones> Ubicacion { get; set; }
    }
}
