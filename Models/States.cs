using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace WatchingOrchestrator.Models{
    public class States : BaseModel{
        [Key]
        [Required]
        public int StatesId { get; set; }
        [Required]
        public string StatesName { get; set; }
        public List<Elements> ElementsList { get; set; }
        
        public States() : base()
        {
            
        }
        public States(string statesName,
                        DateTime startDate,
                        DateTime endDate,
                        DateTime updDate) : base(startDate, endDate, updDate)
        {
            this.StatesName = statesName;
        }
    }
}