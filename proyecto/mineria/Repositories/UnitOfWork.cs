using mineria.Data;
using mineria.Interfaces;
using mineria.Repositories;

namespace ApiUsuarios.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MiBaseContext _context;
        private IUsuarioRepository? _usuarioRepository;
        private IAnalisisLabotarioRepository? _analisisLabotarioRepository;

        public UnitOfWork(MiBaseContext context)
        {
            _context = context;
        }

        public IUsuarioRepository Usuarios
            => _usuarioRepository ??= new UsuarioRepository(_context);
        public IAnalisisLabotarioRepository AnalisisLabotario
            => _analisisLabotarioRepository ??= new AnalisisRepository(_context);

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
