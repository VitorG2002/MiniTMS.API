using AutoMapper;
using MiniTMS.API.Interfaces;
using MiniTMS.Dominio._Base;
using MiniTMS.Dominio.Produto;

namespace MiniTMS.API.Services
{
    public class ProdutoServices : IProduto
    {
        private readonly IRepositorio<Produtos> _repositorio;
        private readonly IMapper _mapper;

        public ProdutoServices(IRepositorio<Produtos> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public List<ReadProdutoDto> BuscarLista()
        {
            var listaProduto = _repositorio.GetAll();

            var listaRetorno = _mapper.Map<List<ReadProdutoDto>>(listaProduto);

            return listaRetorno;
        }

        public ReadProdutoDto BuscarPorId(int id)
        {
            var produto = _repositorio.Get(id);
            var retorno = _mapper.Map<ReadProdutoDto>(produto);

            return retorno;
        }


        public CreateProdutoDto Adicionar(CreateProdutoDto produtoDto)
        {
            Produtos produto = _mapper.Map<Produtos>(produtoDto);
            _repositorio.Add(produto);
            return produtoDto;
        }

        public Produtos Editar(UpdateProdutoDto produtoDto)
        {
            Produtos produto = _repositorio.Get(produtoDto.Id);
            produto = _mapper.Map(produtoDto, produto);

            if (produto != null)
                _repositorio.Update(produto);
            return produto;
        }

        public bool Excluir(int id)
        {
            var sucesso = _repositorio.Delete(id);
            return sucesso;
        }
    }
}
