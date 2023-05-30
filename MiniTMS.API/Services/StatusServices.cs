using AutoMapper;
using MiniTMS.API.Interfaces;
using MiniTMS.Dominio._Base;
using MiniTMS.Dominio.Status;

namespace MiniTMS.API.Services
{
    public class StatusServices : IStatus
    {
        private readonly IRepositorio<Statuses> _repositorio;
        private readonly IMapper _mapper;

        public StatusServices(IRepositorio<Statuses> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public List<ReadStatusDto> BuscarLista()
        {
            var listaStatuses = _repositorio.GetAll();

            var listaRetorno = _mapper.Map<List<ReadStatusDto>>(listaStatuses);

            return listaRetorno;
        }

        public ReadStatusDto BuscarPorId(int id)
        {
            var status = _repositorio.Get(id);
            var retorno = _mapper.Map<ReadStatusDto>(status);

            return retorno;
        }


        public CreateStatusDto Adicionar(CreateStatusDto statusDto)
        {
            Statuses status = _mapper.Map<Statuses>(statusDto);
            _repositorio.Add(status);
            return statusDto;
        }

        public Statuses Editar(UpdateStatusDto statusDto)
        {
            Statuses status = _repositorio.Get(statusDto.Id);
            status = _mapper.Map(statusDto, status);

            if(status != null)
            _repositorio.Update(status);
            return status;
        }

        public bool Excluir(int id)
        {
            var sucesso = _repositorio.Delete(id);
            return sucesso;
        }
    }
}
