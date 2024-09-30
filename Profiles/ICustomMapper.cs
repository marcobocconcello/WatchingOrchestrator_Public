using System.Collections.Generic;
using WatchingOrchestrator.Dto;
using WatchingOrchestrator.Models;

namespace WatchingOrchestrator.Profiles
{
    public interface ICustomMapper
    {
        public List<ContentsDto> fromContentsToContentsDto(List<Contents> contents);
        public List<ElementsDto> fromElementsToElementsDto(List<Elements> elements);
    }
}
