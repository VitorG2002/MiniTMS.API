using AutoMapper;
using MiniTMS.Dominio.Produto;

namespace MiniTMS.API.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<CreateProdutoDto, Produtos>();
            CreateMap<Produtos, ReadProdutoDto>();
            CreateMap<UpdateProdutoDto, Produtos>();
        }
    }
}
