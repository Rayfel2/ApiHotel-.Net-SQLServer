namespace APIHotel.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public int ConteoAccesosFallidos { get; set; }
        public string Email { get; set; }
        public int EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string NumeroTelefono { get; set; }
        public int NumeroTelefonoConfirmed { get; set; }
        public int IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<RolesUsuarios> rolesUsuarios { get; set; }
        public virtual ICollection<Huespedes> Huespedes { get; set; }
        public virtual ICollection<Empleados> Empleados { get; set; }



    }
}
