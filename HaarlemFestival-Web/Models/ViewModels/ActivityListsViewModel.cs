using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Models
{
    public class ActivityListsViewModel
    {
        public int SelectedItemId { get; set; }

        public IEnumerable<Walking> WalkingActivities { get; set; }
        public IEnumerable<Dining> DiningActivities { get; set; }
        public IEnumerable<Talking> TalkingActivities { get; set; }
        public IEnumerable<Jazz> JazzActivities { get; set; }
    }
}