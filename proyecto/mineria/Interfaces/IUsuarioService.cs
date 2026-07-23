using Microsoft.AspNetCore.Mvc;
using mineria.Data;
using mineria.Dtos;

namespace mineria.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> GetAllAsync();
        Task<UsuarioDto?> GetByIdAsync(int id);
        Task<UsuarioDto> AddAsync(UsuarioCreateDto dto);
        Task<bool> UpdateAsync(int id, UsuarioUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<ApiResponse<IEnumerable<UsuarioDto>>> GetFiltradoAsync(PostQueryFilter filter);
    }
}
