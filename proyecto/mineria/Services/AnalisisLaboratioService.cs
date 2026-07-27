using AutoMapper;
using mineria.Dtos;
using mineria.Interfaces;
using mineria.Models;

namespace mineria.Services
{
    public class AnalisisLaboratioService : IAnalisisLaboratorioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public AnalisisLaboratioService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<IEnumerable<AnalisisLabotarioDto>> GetAllAsync()
        {
            var analisislaboratorio = await _unitOfWork.AnalisisLabotario.GetAllAsync();
            return _mapper.Map<IEnumerable<AnalisisLabotarioDto>>(analisislaboratorio);
        }

        public async Task<AnalisisLabotarioDto?> GetByIdAsync(int id)
        {
            var analisislaboratorio = await _unitOfWork.AnalisisLabotario.GetByIdAsync(id);
            if (analisislaboratorio == null)
                return null;

            return _mapper.Map<AnalisisLabotarioDto>(analisislaboratorio);
        }

        public async Task<AnalisisLabotarioDto> AddAsync(AnalisisLaboratorioCreateDto dto)
        {
            var existe = await _unitOfWork.AnalisisLabotario.GetByEstadoAnalisisAsync(dto.EstadoAnalisis);
            if (existe != null)
                throw new Exception("Ya existe el analisis //considerar para ver que parametro utilizar para la busqueda//.");

            var analisislaboratorio = _mapper.Map<AnalisisLaboratorio>(dto);
            analisislaboratorio. = _passwordHasher.HashPassword(dto.Clave);

            await _unitOfWork.AnalisisLabotario.AddAsync(analisislaboratorio);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<AnalisisLabotarioDto>(analisislaboratorio);
        }

        public async Task<bool> UpdateAsync(int id, AnalisisLaborioUpdateDto dto)
        {
            if (id != dto.Id)
                return false;

            var analisislaboratorio = await _unitOfWork.AnalisisLabotario.GetByIdAsync(id);
            if (analisislaboratorio == null)
                return false;

            analisislaboratorio.LeyOro = dto.LeyOro;
            analisislaboratorio.LeyPlata = dto.LeyPlata;
            analisislaboratorio.LeyCobre = dto.LeyCobre;
            analisislaboratorio.ImpurezasPorcentaje = dto.ImpurezasPorcentaje;
            analisislaboratorio.EstadoAnalisis = dto.EstadoAnalisis;
            analisislaboratorio.CertificadoPdfUrl = dto.CertificadoPdfUrl;

            if (!string.IsNullOrWhiteSpace(dto.Clave))
            {
                analisislaboratorio.Clave = _passwordHasher.HashPassword(dto.Clave);
            }

            _unitOfWork.AnalisisLabotario.Update(analisislaboratorio);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var analisislaboratorio = await _unitOfWork.AnalisisLabotario.GetByIdAsync(id);
            if (analisislaboratorio == null)
                return false;

            await _unitOfWork.AnalisisLabotario.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
