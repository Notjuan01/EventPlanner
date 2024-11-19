namespace EventPlanner.Models
{
    public class Evento
    {
     public int IdEvento { get; set; }
     
        public string EventoName { get; set; }
        public string EventoDescription { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin {  get; set; }
        public int IdUbicacion { get; set; }

    }
}
