namespace APIHotel.Dto
{
    public class TarjetaDTO
    {
        public int IdTarjetaDeCredito { get; set; }
        public int Numero { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string CVV { get; set; }
        public string NombreTitular { get; set; }
        public bool IsDeleted { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }

        // CONSTRUCTOR
        public TarjetaDTO()
        {
            IsDeleted = false;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
