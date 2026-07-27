namespace mineria.Dtos
{
    public class AnalisisLaborioUpdateDto
    {
        public int Id { get; set; }
        public decimal LeyOro { get; set; }
        public decimal LeyPlata { get; set; }
        public decimal LeyCobre { get; set; }
        public decimal ImpurezasPorcentaje { get; set; }
        public string EstadoAnalisis { get; set; } = string.Empty;
        public string CertificadoPdfUrl { get; set; } = string.Empty;
    }
}
