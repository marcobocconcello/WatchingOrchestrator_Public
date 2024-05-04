using System.Collections.Generic;

namespace WatchingOrchestrator.Dto{
    public class ResponseSates : BaseResponse{
        public StatesDto StatesDto { get; set; }
        public List<ElementsDto> ElementsDtos { get; set; }

        public ResponseSates() : base()
        {
            
        }
        public ResponseSates(StatesDto statesDto, 
                                List<ElementsDto> elementsDto,
                                int statusCode,
                                string errorCode,
                                string errorMessage) : base(statusCode, errorCode, errorMessage)
        {
            this.StatesDto = statesDto;
            this.ElementsDtos = elementsDto;
        }
    }
}