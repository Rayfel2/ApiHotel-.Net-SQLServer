namespace APIHotel.Dto
{
    public class ReservacionDto
    {
        public int IdReservacion { get; set; }
        public bool checkin { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public int Cantidad { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
