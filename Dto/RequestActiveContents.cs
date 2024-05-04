using System;

namespace WatchingOrchestrator.Dto{
    public class RequestActiveContents{
        public int? ContentsId { get; set; }
        public DateTime? DataRiferimento { get; set; }
        public RequestActiveContents(int contentsId, DateTime dataRiferimento)
        {
            this.ContentsId = contentsId;
            this.DataRiferimento = dataRiferimento;
        }
    }
}