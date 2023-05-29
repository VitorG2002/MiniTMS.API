using AutoMapper;
using MiniTMS.Dominio.Endereco;

namespace MiniTMS.API.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Enderecos>();
        }
    }
}
