using System.Collections.Generic;

namespace WatchingOrchestrator.Dto
{
    public class ResposeContents: BaseResponse{
        public List<ContentsDto> ContentsDto { get; set; }
        public ResposeContents() : base()
        {
            
        }

        public ResposeContents(List<ContentsDto> contentsDto,
                                int statusCode,
                                string errorCode,
                                string errorMessage) : base(statusCode, errorCode, errorMessage)
        {
            this.ContentsDto = contentsDto;
        }
    }
}