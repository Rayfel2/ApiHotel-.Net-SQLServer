namespace APIHotel.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<RolesUsuarios> rolesUsuarios { get; set; }
    }
}
