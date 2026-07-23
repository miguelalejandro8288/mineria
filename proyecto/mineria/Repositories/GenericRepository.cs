using Microsoft.EntityFrameworkCore;
using mineria.Data;
using mineria.Interfaces;
using mineria.Models;

namespace mineria.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly MiBaseContext _context;
        protected readonly DbSet<T> _entities;

        public GenericRepository(MiBaseContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities
                .AsNoTracking()
                .Where(x => x.Borrado == false)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _entities
                .FirstOrDefaultAsync(x => x.Id == id && x.Borrado == false);
        }

        public async Task AddAsync(T entity)
        {
            entity.FechaCreacion = DateTime.Now;
            entity.Borrado = false;
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _entities.FirstOrDefaultAsync(x => x.Id == id && x.Borrado == false);
            if (entity != null)
            {
                entity.Borrado = true;
                _entities.Update(entity);
            }
        }
        public IQueryable<T> GetAllAsQueryable()
        {
            return _entities
                .AsNoTracking()
                .Where(x => x.Borrado == false)
                .OrderByDescending(x => x.Id)
                .AsQueryable();
        }

    }
}
