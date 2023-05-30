using AutoMapper;
using MiniTMS.Dominio.Cliente;

namespace MiniTMS.API.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<CreateClienteDto, Clientes>()
            .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco));
            CreateMap<Clientes, ReadClienteDto>()
                .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco));
            CreateMap<UpdateClienteDto, Clientes>()
            .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco));

        }
    }
}
