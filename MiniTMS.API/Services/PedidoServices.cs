using AutoMapper;
using MiniTMS.API.Interfaces;
using MiniTMS.Dominio.Pedido;
using MiniTMS.Dominio.Produto;

namespace MiniTMS.API.Services
{
    public class PedidoServices : IPedido
    {
        private readonly IPedidoRepositorio _repositorio;
        private readonly IMapper _mapper;

        public PedidoServices(IPedidoRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public List<ReadPedidoDto> BuscarLista()
        {
            var listaPedidos = _repositorio.BuscarListaPorIdComRelacionamentos();

            var listaRetorno = _mapper.Map<List<ReadPedidoDto>>(listaPedidos);

            return listaRetorno;
        }

        public ReadPedidoDto BuscarPorId(int id)
        {
            var pedido = _repositorio.BuscarPorIdComRelacionamentos(id);
            var retorno = _mapper.Map<ReadPedidoDto>(pedido);

            return retorno;
        }


        public CreatePedidoDto Adicionar(CreatePedidoDto pedidoDto)
        {
            List<Produtos> produtos = _repositorio.BuscarProdutosRelacionados(pedidoDto.ProdutosIds);
            Pedidos pedido = _mapper.Map<Pedidos>(pedidoDto);

            _repositorio.AdicionarPedidoComProdutos(pedido, produtos);

            return pedidoDto;
        }

        public Pedidos Editar(UpdatePedidoDto pedidoDto)
        {
            Pedidos pedido = _repositorio.BuscarPorIdComRelacionamentos(pedidoDto.Id);
            if(pedido == null)
            {
                throw new ArgumentException("Nenhum pedido encontrado!");
            }

            List<Produtos> produtos = _repositorio.BuscarProdutosRelacionados(pedidoDto.ProdutosIds);

            pedido = _mapper.Map(pedidoDto, pedido);
            pedido.Produtos = produtos;

            _repositorio.Update(pedido);
            return pedido;
        }

        public bool Excluir(int id)
        {
            var sucesso = _repositorio.Delete(id);
            return sucesso;
        }
    }
}
