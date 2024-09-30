using System;

namespace WatchingOrchestrator.Dto{
    public class ElementsDto{
        public int ElementsId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Immage { get; set; }
        public string FlagPiaciuto { get; set; }

         public ElementsDto()
        {
            
        }
        public ElementsDto(int elementsId,
                        DateTime realDate,
                        string title,
                        string description,
                        string immage,
                        string flagPiaciuto)
        {
            this.ElementsId = elementsId;  
            this.ReleaseDate = realDate;
            this.Title = title;
            this.Description = description;
            this.Immage = immage;
            this.FlagPiaciuto = flagPiaciuto;
            
        }
    }
   
}