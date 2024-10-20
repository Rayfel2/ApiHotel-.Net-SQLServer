namespace APIHotel.Models
{
    public class Servicios
    {
        public int IdServicio { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<ServiciosFacturas> ServiciosFacturas { get; set; }
    }
}
