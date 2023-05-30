using AutoMapper;
using MiniTMS.API.Interfaces;
using MiniTMS.Dominio.Entregador;

namespace MiniTMS.API.Services
{
    public class EntregadorServices : IEntregador
    {

        private readonly IEntregadorRepositorio _repositorio;
        private readonly IMapper _mapper;

        public EntregadorServices(IEntregadorRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public List<ReadEntregadorDto> BuscarLista()
        {
            var listaEntregadores = _repositorio.BuscarListaPorIdComEndereco();

            var listaRetorno = _mapper.Map<List<ReadEntregadorDto>>(listaEntregadores);

            return listaRetorno;
        }

        public ReadEntregadorDto BuscarPorId(int id)
        {
            var entregador = _repositorio.BuscarPorIdComEndereco(id);
            var retorno = _mapper.Map<ReadEntregadorDto>(entregador);

            return retorno;
        }


        public CreateEntregadorDto Adicionar(CreateEntregadorDto entregadorDto)
        {
            Entregadores entregador = _mapper.Map<Entregadores>(entregadorDto);
            _repositorio.Add(entregador);
            return entregadorDto;
        }

        public Entregadores Editar(UpdateEntregadorDto entregadorDto)
        {
            Entregadores entregador = _repositorio.BuscarPorIdComEndereco(entregadorDto.Id);
            entregador = _mapper.Map(entregadorDto, entregador);

            _repositorio.Update(entregador);
            return entregador;
        }

        public bool Excluir(int id)
        {
            var sucesso = _repositorio.Delete(id);
            return sucesso;
        }
    }
}
