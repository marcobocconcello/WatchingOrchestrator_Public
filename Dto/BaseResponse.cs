using Microsoft.EntityFrameworkCore.Diagnostics;

namespace WatchingOrchestrator.Dto{        
    public class BaseResponse{
        public int StatusCode { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; } 

        public BaseResponse()
        {
            
        }
        public BaseResponse(int statusCode, string errorCode, string erroMessage)
        {
            this.StatusCode = statusCode;
            this.ErrorCode = errorCode;
            this.ErrorMessage = erroMessage;
        }

    }
}
