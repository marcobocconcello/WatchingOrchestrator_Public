using System.Collections.Generic;

namespace WatchingOrchestrator.Dto{
        public class ContentsDto{
            public int ContentsId { get; set; }
            public string ContentsType { get; set; }
            public List<ElementsDto> elementsList  {get; set;} 

            public ContentsDto()
            {
                
            }
            public ContentsDto(int id, string contentsType, List<ElementsDto> elementsDtos)
            {
                this.ContentsId = id;
                this.ContentsType = contentsType;
                this.elementsList = elementsDtos;
            }
        
    }
}