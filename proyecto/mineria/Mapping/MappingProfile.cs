using AutoMapper;
using mineria.Dtos;
using mineria.Models;

namespace mineria.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioCreateDto, Usuario>();
            CreateMap<UsuarioUpdateDto, Usuario>();

            CreateMap<AnalisisLaboratorio, AnalisisLabotarioDto>();
            CreateMap<AnalisisLaboratorioCreateDto, AnalisisLaboratorio>();
            CreateMap<AnalisisLaborioUpdateDto, AnalisisLaboratorio>();
        }
    }
}
