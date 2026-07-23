using mineria.Data;
using mineria.Dtos;
using mineria.Models;

namespace mineria.Interfaces
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<Usuario?> GetByCorreoAsync(string correo);
        Task<PagedList<Usuario>> GetFiltradoAsync(PostQueryFilter filter);

    }
}

