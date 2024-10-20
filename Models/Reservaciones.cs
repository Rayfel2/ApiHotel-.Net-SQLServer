namespace APIHotel.Models
{
    public class Reservaciones
    {
        public int IdReservacion { get; set; }
        public bool checkin { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public int Cantidad { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Facturas> Facturas { get; set; } 
    }
}
