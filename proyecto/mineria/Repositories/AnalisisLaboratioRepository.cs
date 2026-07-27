using Microsoft.EntityFrameworkCore;
using mineria.Data;
using mineria.Dtos;
using mineria.Interfaces;
using mineria.Models;

namespace mineria.Repositories
{
    public class AnalisisRepository : GenericRepository<AnalisisLaboratorio>, IAnalisisLabotarioRepository
    {
        public AnalisisRepository(MiBaseContext context) : base(context)
        {
        }

        public Task<AnalisisLaboratorio?> GetByEstadoAnalisisAsync(string estadoAnalisis)
        {
            return _context.AnalisisLaboratorios
                .FirstOrDefaultAsync(x => x.EstadoAnalisis == estadoAnalisis && x.Borrado == false);
        }

        public async Task<PagedList<AnalisisLaboratorio>> GetFiltradoAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    x.LeyOro.ToString().Contains(buscar) ||
                    x.LeyPlata.ToString().Contains(buscar) ||
                    x.LeyCobre.ToString().Contains(buscar) ||
                    x.ImpurezasPorcentaje.ToString().Contains(buscar) ||
                    x.EstadoAnalisis.ToLower().Contains(buscar) ||
                    x.CertificadoPdfUrl.ToLower().Contains(buscar));
            }

            return await PagedList<AnalisisLaboratorio>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }



    }
}



