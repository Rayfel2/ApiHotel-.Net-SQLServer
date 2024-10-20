namespace APIHotel.Models
{
    public class ServiciosFacturas
    {
        public int IdServicio { get; set; }
        public int IdFacturas { get; set; }
        public Servicios Servicios { get; set; }
        public Facturas Facturas { get; set; }


    }
}
