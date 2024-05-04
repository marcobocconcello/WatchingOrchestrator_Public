using System.Collections.Generic;

namespace WatchingOrchestrator.Dto{
    public class ResponseElements : BaseResponse
    {
        public ContentsDto ContentsDto { get; set; }
        public StatesDto StatesDto { get; set; }
        public List<ElementsDto> ElementsDto { get; set; }
        public ResponseElements() : base()
        {
        }

        public ResponseElements(ContentsDto contentsDto,
                                StatesDto statesDto,
                                List<ElementsDto> elementsDtos,
                                int statusCode,
                                string errorCode,
                                string erroMessage) : base(statusCode, errorCode, erroMessage)
        {
            this.ContentsDto = contentsDto;
            this.StatesDto = statesDto;
            this.ElementsDto = elementsDtos;
        }
    }
}