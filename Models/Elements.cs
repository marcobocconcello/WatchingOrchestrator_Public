using System;
using System.ComponentModel.DataAnnotations;

namespace WatchingOrchestrator.Models{
    public class Elements : BaseModel{
        [Key]
        [Required]
        public int ElementsId { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Immage { get; set; }
        [Required]
        public string FlagPiaciuto { get; set; }
        public int ContentsId { get; set; }
        public Contents Categoria { get; set; }
        public int StatesId { get; set; }
        public States Stato { get; set; }
        
        public Elements() : base()
        {
            
        }
        public Elements(DateTime startDate,
                        DateTime endDate,
                        DateTime updDate,
                        DateTime realDate,
                        string title,
                        string description,
                        string immage,
                        string flagPiaciuto) : base(startDate, endDate, updDate)
        {
            this.ReleaseDate = realDate;
            this.Title = title;
            this.Description = description;
            this.Immage = immage;
            this.FlagPiaciuto = flagPiaciuto;
            
        }
        public Elements(DateTime startDate,
                        DateTime endDate,
                        DateTime updDate,
                        DateTime realDate,
                        string title,
                        string description,
                        string immage,
                        string flagPiaciuto,
                        int idCategoria,
                        int idStato) : base(startDate, endDate, updDate)
        {
            this.ReleaseDate = realDate;
            this.Title = title;
            this.Description = description;
            this.Immage = immage;
            this.FlagPiaciuto = flagPiaciuto;
            this.StatesId = idStato;
            this.ContentsId = idCategoria;
        }

        public Elements(DateTime startDate,
                        DateTime endDate,
                        DateTime updDate,
                        DateTime realDate,
                        string title,
                        string description,
                        string immage,
                        string flagPiaciuto,
                        int idCategoria,
                        int idStato,
                        Contents categoria,
                        States stato) : base(startDate, endDate, updDate)
        {
            this.ReleaseDate = realDate;
            this.Title = title;
            this.Description = description;
            this.Immage = immage;
            this.FlagPiaciuto = flagPiaciuto;
            this.StatesId = idStato;
            this.ContentsId = idCategoria;
            this.Categoria = categoria;
            this.Stato = stato;
        }
    }
}