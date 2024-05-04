namespace WatchingOrchestrator.Dto{
        public class StatesDto {
            public int StatesId { get; set; }
            public string StatesName { get; set; }
            public StatesDto() : base()
            {
                
            }
            public StatesDto(int id , string statesName)
            {
                this.StatesId = id;
                this.StatesName = statesName;
            }
        
    }
}