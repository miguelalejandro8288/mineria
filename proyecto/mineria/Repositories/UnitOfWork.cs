using mineria.Data;
using mineria.Interfaces;

namespace mineria.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MiBaseContext _context;
        private IUsuarioRepository? _usuarioRepository;

        public UnitOfWork(MiBaseContext context)
        {
            _context = context;
        }

        public IUsuarioRepository Usuarios
            => _usuarioRepository ??= new UsuarioRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
