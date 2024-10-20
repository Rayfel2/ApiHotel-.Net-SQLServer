namespace APIHotel.Models
{
    public class Huespedes
    {
        public int IdHuesped { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Reservaciones> Reservaciones { get; set; }
        public virtual ICollection<Tarjetas_de_creditos> Tarjetas { get; set; }
    }
}
