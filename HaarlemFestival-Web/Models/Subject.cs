using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Models
{
    /// <summary>
    /// A subject represents a main event inside of the Haarlem Festival.
    /// 
    /// The Haarlem Festival will start off with four subjects.
    /// More subjects can easily be added.
    /// </summary>

    public class Subject
    {
        [Key]
        public int Id { get; private set; }

        // Non-referencing properties
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        // Referencing properties
        // A single subject can contain many activities. 
        public virtual ICollection<Activity> Activities { get; set; }
    }
}