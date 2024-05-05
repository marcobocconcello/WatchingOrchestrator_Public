using System.Collections.Generic;

namespace WatchingOrchestrator.Dto{
    public class ResponseElements : BaseResponse
    {
        public List<ElementsDto> ElementsDto { get; set; }
        public ResponseElements() : base()
        {
        }

        public ResponseElements(List<ElementsDto> elementsDtos,
                                int statusCode,
                                string errorCode,
                                string erroMessage) : base(statusCode, errorCode, erroMessage)
        {
            this.ElementsDto = elementsDtos;
        }
    }
}