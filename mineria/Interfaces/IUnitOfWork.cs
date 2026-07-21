namespace mineria.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository Usuarios { get; }
        Task<int> SaveChangesAsync();
    }
}
