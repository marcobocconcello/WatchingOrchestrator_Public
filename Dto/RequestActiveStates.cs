using System;

namespace WatchingOrchestrator.Dto{
    public class RequestActiveStates{
        public int? StatesId { get; set; }
        public DateTime? DataRiferimento { get; set; }

        public RequestActiveStates()
        {
            
        }

        public RequestActiveStates(int statesId, DateTime dataRiferimento)
        {
            this.StatesId = statesId;
            this.DataRiferimento = dataRiferimento;
        }
    }
}