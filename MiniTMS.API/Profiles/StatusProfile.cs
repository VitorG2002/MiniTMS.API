using AutoMapper;
using MiniTMS.Dominio.Status;

namespace MiniTMS.API.Profiles
{
    public class StatusProfile : Profile
    {
        public StatusProfile()
        {
            CreateMap<CreateStatusDto, Statuses>();
            CreateMap<Statuses, ReadStatusDto>();
            CreateMap<UpdateStatusDto, Statuses>();
        }
    }
}
