namespace APIHotel.Dto
{
    public class HuespedDTO
    {
        public int IdHuesped { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public bool IsDeleted { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }

        // constructor
        public HuespedDTO()
        {
            IsDeleted = false;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;

        }
    }
}
