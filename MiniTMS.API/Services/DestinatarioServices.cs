using AutoMapper;
using MiniTMS.API.Interfaces;
using MiniTMS.Dominio.Destinatario;

namespace MiniTMS.API.Services
{
    public class DestinatarioServices : IDestinatario
    {
        private readonly IDestinatarioRepositorio _repositorio;
        private readonly IMapper _mapper;

        public DestinatarioServices(IDestinatarioRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public List<ReadDestinatarioDto> BuscarLista()
        {
            var listaDestinatarios = _repositorio.BuscarListaPorIdComEndereco();

            var listaRetorno = _mapper.Map<List<ReadDestinatarioDto>>(listaDestinatarios);

            return listaRetorno;
        }

        public ReadDestinatarioDto BuscarPorId(int id)
        {
            var destinatario = _repositorio.BuscarPorIdComEndereco(id);
            var retorno = _mapper.Map<ReadDestinatarioDto>(destinatario);

            return retorno;
        }


        public CreateDestinatarioDto Adicionar(CreateDestinatarioDto destinatarioDto)
        {
            Destinatarios destinatario = _mapper.Map<Destinatarios>(destinatarioDto);
            _repositorio.Add(destinatario);

            return destinatarioDto;
        }

        public Destinatarios Editar(UpdateDestinatarioDto destinatarioDto)
        {
            Destinatarios destinatario = _repositorio.BuscarPorIdComEndereco(destinatarioDto.Id);
            destinatario = _mapper.Map(destinatarioDto, destinatario);

            _repositorio.Update(destinatario);
            return destinatario;
        }

        public bool Excluir(int id)
        {
            var sucesso = _repositorio.Delete(id);
            return sucesso;
        }
    }
}
