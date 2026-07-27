namespace mineria.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository Usuarios { get; }
        IAnalisisLabotarioRepository AnalisisLabotario { get; }
        
        Task<int> SaveChangesAsync();
    }

}
