using AutoMapper;
using mineria.Data;
using mineria.Dtos;
using mineria.Interfaces;
using mineria.Models;

namespace mineria.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public UsuarioService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<IEnumerable<UsuarioDto>> GetAllAsync()
        {
            var usuarios = await _unitOfWork.Usuarios.GetAllAsync();
            return _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
        }

        public async Task<UsuarioDto?> GetByIdAsync(int id)
        {
            var usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);
            if (usuario == null)
                return null;

            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<UsuarioDto> AddAsync(UsuarioCreateDto dto)
        {
            var existe = await _unitOfWork.Usuarios.GetByCorreoAsync(dto.Correo);
            if (existe != null)
                throw new Exception("Ya existe un usuario con ese correo.");

            var usuario = _mapper.Map<Usuario>(dto);
            usuario.Contrasena = _passwordHasher.HashPassword(dto.Contrasena);

            await _unitOfWork.Usuarios.AddAsync(usuario);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<bool> UpdateAsync(int id, UsuarioUpdateDto dto)
        {
            if (id != dto.Id)
                return false;

            var usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);
            if (usuario == null)
                return false;

            usuario.Nombre = dto.Nombre;
            usuario.Correo = dto.Correo;
            usuario.Rol = dto.Rol;

            if (!string.IsNullOrWhiteSpace(dto.Contrasena))
            {
                usuario.Contrasena = _passwordHasher.HashPassword(dto.Contrasena);
            }

            _unitOfWork.Usuarios.Update(usuario);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);
            if (usuario == null)
                return false;

            await _unitOfWork.Usuarios.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<ApiResponse<IEnumerable<UsuarioDto>>> GetFiltradoAsync(PostQueryFilter filter)
        {
            var usuarios = await _unitOfWork.Usuarios.GetFiltradoAsync(filter);
            var usuariosDto = _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);

            return new ApiResponse<IEnumerable<UsuarioDto>>(usuariosDto, usuarios.MetaData);
        }

    }
}
