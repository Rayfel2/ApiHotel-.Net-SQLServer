namespace APIHotel.Dto
{
    public class FacturaDto
    {
        public int IdFactura { get; set; }
        public int MontoTotal { get; set; }
        public DateTime Fecha { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
