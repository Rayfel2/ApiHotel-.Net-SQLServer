namespace APIHotel.Dto
{
    public class UsuariosDto
    {
        public int Id { get; }
        public int ConteoAccesosFallidos { get; }
        public string Email { get; set; }
        public int EmailConfirmed { get; }
        public string PasswordHash { get; set; }
        public string NumeroTelefono { get; set; }
        public int NumeroTelefonoConfirmed { get; }
        public bool IsDeleted { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
        public UsuariosDto()
        {
            ConteoAccesosFallidos = 0;
            EmailConfirmed = 1;
            NumeroTelefonoConfirmed = 1;
            IsDeleted = false;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }

}
