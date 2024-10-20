namespace APIHotel.Models
{
    public class Habitaciones
    {
        public int IdHabitacion { get; set; }
        public string Descripcion { get; set; }
        public int Limite { get; set; }
        public int Precio { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Reservaciones> Reservaciones { get; set; }
    }
}
