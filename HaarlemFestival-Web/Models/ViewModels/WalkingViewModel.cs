using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Models
{
    [NotMapped]
    public class WalkingViewModel : Walking
    {
        public WalkingViewModel(string Name, string Description, int Capacity, decimal Price, DateTime StartTime, DateTime EndTime, int SubjectId)
        {
            this.Name = Name;
            this.Description = Description;
            this.Capacity = Capacity;
            this.Price = Price;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.SubjectId = SubjectId;
        }
    }
}