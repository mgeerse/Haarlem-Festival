using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Models
{
    /// <summary>
    /// Describes a certain activity inside one of the main events (subjects) of the festival.
    /// 
    /// For example, a performance of a Jazz band at the Patronaat could be an activity inside of the
    /// Jazz@Patronaat subject.
    /// </summary>
    public class Activity
    {
        [Key]
        public int Id { get; private set; }

        // Non-referencing properties
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        // Referencing properties

        // An activity belongs to a single subject. Using an additional integer pointing 
        // to the Id forces non-nullability (An activity needs to be member of exactly one subject).
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}