using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INF2._2_Project_HaarlemFestival.Models
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public DateTime Duration { get; set; }
        public DateTime StartTime { get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; private set; }

        //Constructor:
        public Activity(int ActivityId, string Name, string Description, int Capacity, DateTime Duration, DateTime StartTime, Subject Subject)
        {
            this.ActivityId = ActivityId;
            this.Name = Name;
            this.Description = Description;
            this.Capacity = Capacity;
            this.Duration = Duration;
            this.StartTime = StartTime;
            this.Subject = Subject;
        }

        //TODO: Hier methodes om properties binnen dit object te wijzigen:
        //....
    }
}