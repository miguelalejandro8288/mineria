using mineria.Dtos;
using mineria.Interfaces;

namespace mineria.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public AuthService(
            IUnitOfWork unitOfWork,
            IPasswordHasher passwordHasher,
            ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
        {
            var usuario = await _unitOfWork.Usuarios.GetByCorreoAsync(dto.Correo);

            if (usuario == null)
                return null;

            var claveValida = _passwordHasher.VerifyPassword(dto.Contraseña, usuario.Contrasena);

            if (!claveValida)
                return null;

            return _tokenService.GenerateToken(usuario);
        }
    }
}
