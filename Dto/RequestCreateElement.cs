using System;

namespace WatchingOrchestrator.Dto{
    public class RequestCreateElement{
        public DateTime ReleaseDate {get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Immage { get; set; }
        public string? FlagPiaciuto { get; set; }
        public int ContentsId { get; set; }
        public int StatesId { get; set; }

        public RequestCreateElement()
        {
            
        }
        public RequestCreateElement(DateTime realDate,
                                    string title,
                                    string description,
                                    string immage,
                                    string flagPiaciuto,
                                    int idCategoria,
                                    int idStato)
        {
            this.ReleaseDate = realDate;
            this.Title = title;
            this.Description = description;
            this.Immage = immage;
            this.FlagPiaciuto = flagPiaciuto;
            this.StatesId = idStato;
            this.ContentsId = idCategoria;
        }
    }
}