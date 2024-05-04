using System.Runtime.InteropServices;
using AutoMapper;
using WatchingOrchestrator.Dto;
using WatchingOrchestrator.Models;

namespace WatchingOrchestrator.Profiles{
    public class WatchingProfile : Profile{
        public WatchingProfile()
        {
            CreateMap<Contents, ContentsDto>();
            CreateMap<States, StatesDto>();
            CreateMap<Elements, ElementsDto>();
        }
    }
}