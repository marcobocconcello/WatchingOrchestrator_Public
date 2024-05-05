using System;

namespace WatchingOrchestrator.Dto{
    public class RequestUpdateElements{
        public DateTime? NewReleaseDate { get; set; }
        public string NewTitle { get; set; }
        public string NewDescription { get; set; }
        public string NewImmage { get; set; }
        public string NewFlagPiaciuto { get; set; }
        public int? NewContentsId { get; set; }
        public int? NewStatesId { get; set; }

        public RequestUpdateElements()
        {
            
        }
        public RequestUpdateElements(DateTime NewReleaseDate,
                        string NewTitle,
                        string NewDescription,
                        string NewImmage,
                        string NewFlagPiaciuto,
                        int NewContentsId,
                        int NewStatesId)
        {
            this.NewReleaseDate = NewReleaseDate;
            this.NewTitle = NewTitle;
            this.NewDescription = NewDescription;
            this.NewImmage = NewImmage;
            this.NewFlagPiaciuto = NewFlagPiaciuto;
            this.NewContentsId = NewContentsId;
            this.NewStatesId = NewStatesId;
        }
    }
}