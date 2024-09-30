using System.Runtime.InteropServices;
using AutoMapper;
using WatchingOrchestrator.Dto;
using WatchingOrchestrator.Models;

namespace WatchingOrchestrator.Profiles{
    public class WatchingProfile : Profile{
        public WatchingProfile()
        {
            CreateMap<Contents, ContentsDto>()
                .ForMember(c => c.ContentsId,
                cdto => cdto.MapFrom(content => content.ContentsId));
            CreateMap<States, StatesDto>();
            CreateMap<Elements, ElementsDto>();
        }
    }
}