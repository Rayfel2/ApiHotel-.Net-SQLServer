namespace APIHotel.Models
{
    public class Tarjetas_de_creditos
    {
        public int IdTarjetaDeCredito { get; set; }
        public int Numero { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string CVV { get; set; }
        public string NombreTitular { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
