using AutoMapper;
using MiniTMS.Dominio.Pedido;

namespace MiniTMS.API.Profiles
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<CreatePedidoDto, Pedidos>();
         //.ForMember(dest => dest.Destinatario, opt => opt.MapFrom(src => src.Destinatario))
         //.ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente))
         //.ForMember(dest => dest.Entregador, opt => opt.MapFrom(src => src.Entregador))
         //.ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
         //.ForMember(dest => dest.Produtos, opt => opt.MapFrom(src => src.Produtos));

            CreateMap<Pedidos, ReadPedidoDto>()
         .ForMember(dest => dest.Destinatario, opt => opt.MapFrom(src => src.Destinatario))
         .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente))
         .ForMember(dest => dest.Entregador, opt => opt.MapFrom(src => src.Entregador))
         .ForPath(dest => dest.Destinatario.Endereco, opt => opt.MapFrom(src => src.Destinatario.Endereco))
         .ForPath(dest => dest.Cliente.Endereco, opt => opt.MapFrom(src => src.Cliente.Endereco))
         .ForPath(dest => dest.Entregador.Endereco, opt => opt.MapFrom(src => src.Entregador.Endereco))
         .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
         .ForMember(dest => dest.Produtos, opt => opt.MapFrom(src => src.Produtos));

            CreateMap<UpdatePedidoDto, Pedidos>();
         //.ForMember(dest => dest.Destinatario, opt => opt.MapFrom(src => src.Destinatario))
         //.ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente))
         //.ForMember(dest => dest.Entregador, opt => opt.MapFrom(src => src.Entregador))
         //.ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
         //.ForMember(dest => dest.Produtos, opt => opt.MapFrom(src => src.Produtos));
        }
    }
}
