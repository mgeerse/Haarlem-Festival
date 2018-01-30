using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaarlemFestival_Web.Models
{
    [Table("Walking")]
    public class Walking : Activity
    {
        public virtual ICollection<Location> TourLocations { get; set; }

        public int TourGuideId { get; set; }
        public TourGuide TourGuide { get; set; }
    }
}