using Microsoft.EntityFrameworkCore;
using mineria.Data;
using mineria.Dtos;
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

        public async Task<PagedList<Usuario>> GetFiltradoAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    x.Nombre.ToLower().Contains(buscar) ||
                    x.Correo.ToLower().Contains(buscar) ||
                    x.Rol.ToLower().Contains(buscar));
            }

            return await PagedList<Usuario>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }



    }
}

