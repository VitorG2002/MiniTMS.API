using AutoMapper;
using MiniTMS.API.Interfaces;
using MiniTMS.Dominio._Base;
using MiniTMS.Dominio.Cliente;
using MiniTMS.Dominio.Endereco;

namespace MiniTMS.API.Services
{
    public class ClienteServices : ICliente
    {
        private readonly IRepositorio<Clientes> _repositorio;
        private readonly IMapper _mapper;

        public ClienteServices(IRepositorio<Clientes> repositorio, IMapper mapper) 
        { 
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public List<ReadClienteDto> BuscarLista()
        {
            var listaClientes = _repositorio.GetAll();
            var listaRetorno = _mapper.Map<List<ReadClienteDto>>(listaClientes);

            return listaRetorno;
        }

        public ReadClienteDto BuscarPorId(int id)
        {
            var cliente = _repositorio.Get(id);
            var retorno = _mapper.Map<ReadClienteDto>(cliente);

            return retorno;
        }


        public Clientes Adicionar(CreateClienteDto clienteDto)
        {
            Clientes cliente = _mapper.Map<Clientes>(clienteDto);
            cliente.Endereco = _mapper.Map<Enderecos>(clienteDto.Endereco);
            _repositorio.Add(cliente);
            return cliente;
        }
    }
}
