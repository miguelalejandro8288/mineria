using System.ComponentModel.DataAnnotations;

namespace mineria.Dtos
{
    public class VentaCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string NumeroComprobante { get; set; } = string.Empty;
          

        [Required]
        [EmailAddress]
        public string ClienteNombre { get; set; } = string.Empty;

        [Required]
        public string ClienteDocumento { get; set; } = string.Empty;
        public DateTime FechaVenta { get; set; } = DateTime.Now;

        public decimal TotalVendido { get; set; }

        [Required]
        [MaxLength(50)]
        public string Rol { get; set; } = string.Empty;
    }

}
