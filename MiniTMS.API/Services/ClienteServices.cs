using AutoMapper;
using MiniTMS.API.Interfaces;
using MiniTMS.Dominio.Cliente;

namespace MiniTMS.API.Services
{
    public class ClienteServices : ICliente
    {
        private readonly IClienteRepositorio _repositorio;
        private readonly IMapper _mapper;

        public ClienteServices(IClienteRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public List<ReadClienteDto> BuscarLista()
        {
            var listaClientes = _repositorio.BuscarListaPorIdComEndereco();

            var listaRetorno = _mapper.Map<List<ReadClienteDto>>(listaClientes);

            return listaRetorno;
        }

        public ReadClienteDto BuscarPorId(int id)
        {
            var cliente = _repositorio.BuscarPorIdComEndereco(id);
            var retorno = _mapper.Map<ReadClienteDto>(cliente);

            return retorno;
        }


        public CreateClienteDto Adicionar(CreateClienteDto clienteDto)
        {
            Clientes cliente = _mapper.Map<Clientes>(clienteDto);
            _repositorio.Add(cliente);
            return clienteDto;
        }

        public Clientes Editar(UpdateClienteDto clienteDto)
        {
            Clientes cliente = _repositorio.BuscarPorIdComEndereco(clienteDto.Id);
            cliente = _mapper.Map(clienteDto, cliente);

            _repositorio.Update(cliente);
            return cliente;
        }

        public bool Excluir(int id)
        {
            var sucesso = _repositorio.Delete(id);
            return sucesso;
        }
    }
}
