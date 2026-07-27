using mineria.Data;
using mineria.Dtos;
using mineria.Models;

namespace mineria.Interfaces
{
    public interface IAnalisisLabotarioRepository : IGenericRepository <AnalisisLaboratorio>
    {
        Task<AnalisisLaboratorio?> GetByEstadoAnalisisAsync(string estadoAnalisis);
        Task<PagedList<AnalisisLaboratorio>> GetFiltradoAsync(PostQueryFilter filter);

    }
}
