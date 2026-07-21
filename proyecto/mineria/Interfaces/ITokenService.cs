using mineria.Dtos;
using mineria.Models;

namespace mineria.Interfaces
{
    public interface ITokenService
    {
        AuthResponseDto GenerateToken(Usuario usuario);
    }
}
