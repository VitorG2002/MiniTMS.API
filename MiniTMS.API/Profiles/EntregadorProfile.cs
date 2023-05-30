using AutoMapper;
using MiniTMS.Dominio.Entregador;

namespace MiniTMS.API.Profiles
{
    public class EntregadorProfile : Profile
    {
        public EntregadorProfile()
        {
            CreateMap<CreateEntregadorDto, Entregadores>()
            .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco));
            CreateMap<Entregadores, ReadEntregadorDto>()
            .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco));
            CreateMap<UpdateEntregadorDto, Entregadores>()
            .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco));
        }
    }
}
