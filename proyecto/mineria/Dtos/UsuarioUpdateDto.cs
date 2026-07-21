using System.ComponentModel.DataAnnotations;

namespace mineria.Dtos
{
    public class UsuarioUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Correo { get; set; } = string.Empty;

        public string? Contrasena { get; set; }

        [Required]
        [MaxLength(50)]
        public string Rol { get; set; } = string.Empty;
    }
}

