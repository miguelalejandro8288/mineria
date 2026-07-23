using mineria.Models;

namespace mineria.Interfaces
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<Usuario?> GetByCorreoAsync(string correo);
    }
}

