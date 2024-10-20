namespace APIHotel.Models
{
    public class Facturas
    {
        public int IdFactura { get; set; }
        public int MontoTotal { get; set; }
        public DateTime Fecha { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        //public ICollection<Reservaciones> Reservacion { get; set; }
        //public ICollection<Huespedes> Huesped { get; set; }
        public ICollection<ServiciosFacturas> ServiciosFacturas { get; set; }
        public ICollection<CuentasPorCobrar> CuentasPorCobrar { get; set; }


    }
}
