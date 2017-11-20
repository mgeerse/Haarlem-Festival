﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INF2._2_Project_HaarlemFestival.Models
{
    public class Activity
    {
        public int ActivityId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Capacity { get; private set; }
        public DateTime Duration { get; private set; }
        public DateTime StartTime { get; private set; }

        //Verwijzing naar Subject
        [ForeignKey("SubjectId")]
        public Subject Subject { get; private set; }

        [ForeignKey("TicketId")]
        public ICollection<Ticket> Tickets { get; private set; }

        //Constructor:
        public Activity(int ActivityId, string Name, string Description, int Capacity, DateTime Duration, DateTime StartTime)
        {
            this.ActivityId = ActivityId;
            this.Name = Name;
            this.Description = Description;
            this.Capacity = Capacity;
            this.Duration = Duration;
            this.StartTime = StartTime;
        }

        //TODO: Hier methodes om properties binnen dit object te wijzigen:
        //....
    }
}