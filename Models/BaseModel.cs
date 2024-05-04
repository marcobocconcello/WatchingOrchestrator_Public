using System;
using System.ComponentModel.DataAnnotations;

namespace WatchingOrchestrator.Models{
    public class BaseModel{
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate {get; set;}
        [Required]
        public DateTime UpdateDate { get; set; }

        public BaseModel()
        {
            
        }

        public BaseModel(DateTime startDate, DateTime endDate, DateTime updateDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.UpdateDate = updateDate;
        }
    }
}