using AutoMapper;
using MiniTMS.Dominio.Cliente;
using MiniTMS.Dominio.Destinatario;

namespace MiniTMS.API.Profiles
{
    public class DestinatarioProfile : Profile
    {
        public DestinatarioProfile()
        {
            CreateMap<CreateDestinatarioDto, Destinatarios>()
        .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco));
            CreateMap<Destinatarios, ReadDestinatarioDto>()
                .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco));
            CreateMap<UpdateDestinatarioDto, Destinatarios>()
            .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco));
        }
    }
}
