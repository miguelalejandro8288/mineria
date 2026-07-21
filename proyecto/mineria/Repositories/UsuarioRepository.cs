using Microsoft.EntityFrameworkCore;
using mineria.Data;
using mineria.Interfaces;
using mineria.Models;

namespace mineria.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(MiBaseContext context) : base(context)
        {
        }

        public Task<Usuario?> GetByCorreoAsync(string correo)
        {
            return  _context.Usuarios
                .FirstOrDefaultAsync(x => x.Correo == correo && x.Borrado == false);
        }

      
    }
}

