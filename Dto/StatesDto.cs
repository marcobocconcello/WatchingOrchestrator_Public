using System.Collections.Generic;

namespace WatchingOrchestrator.Dto{
        public class StatesDto {
            public int StatesId { get; set; }
            public string StatesName { get; set; }
            public List<ElementsDto> ElementsList { get; set; }
            public StatesDto()
            {
                
            }
            public StatesDto(int id , string statesName, List<ElementsDto> elementsDtos)
            {
                this.StatesId = id;
                this.StatesName = statesName;
                this.ElementsList = elementsDtos;
            }
        
    }
}