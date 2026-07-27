namespace mineria.Dtos
{
    public class AnalisisLaboratorioCreateDto
    {
        public decimal? LeyOro { get; set; }
        public decimal? LeyPlata { get; set; }
        public decimal? LeyCobre { get; set; }
        public decimal? ImpurezasPorcentaje { get; set; }
        public decimal? EstadoAnalisis { get; set; }
        public decimal? CertidicadoPdfUrl { get; set; }
    }
}
