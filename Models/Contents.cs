using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace WatchingOrchestrator.Models{

    public class Contents : BaseModel{
        [Key]
        [Required]
        public int ContentsId { get; set; }
        [Required]
        public string ContentsType { get; set; }
        public List<Elements> ElementsList { get; set; }

        public Contents() : base()
        {
            
        }
        public Contents(string contentsType, 
                        DateTime startDate,
                        DateTime endDate,
                        DateTime upddate) : base(startDate, endDate, upddate)
        {
            this.ContentsType = contentsType;
        }
        
    }

}