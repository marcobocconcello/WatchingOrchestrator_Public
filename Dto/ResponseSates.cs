using System.Collections.Generic;

namespace WatchingOrchestrator.Dto{
    public class ResponseSates : BaseResponse{
        public List<StatesDto> StatesDto { get; set; }

        public ResponseSates() : base()
        {
            
        }
        public ResponseSates(List<StatesDto> statesDto,
                                int statusCode,
                                string errorCode,
                                string errorMessage) : base(statusCode, errorCode, errorMessage)
        {
            this.StatesDto = statesDto;
        }
    }
}