namespace APIHotel.Models
{
    public class CuentasPorCobrar
    {
        public int IdCuenta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int Balance { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}
