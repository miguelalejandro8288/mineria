using mineria.Data;
using mineria.Dtos;

namespace mineria.Interfaces
{
    public interface IAnalisisLaboratorioService
    {
        Task<IEnumerable<AnalisisLabotarioDto>> GetAllAsync();
        Task<AnalisisLabotarioDto?> GetByIdAsync(int id);
        Task<AnalisisLabotarioDto> AddAsync(UsuarioCreateDto dto);
        Task<bool> UpdateAsync(int id, AnalisisLaborioUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<ApiResponse<IEnumerable<AnalisisLabotarioDto>>> GetFiltradoAsync(PostQueryFilter filter);
    }
}
