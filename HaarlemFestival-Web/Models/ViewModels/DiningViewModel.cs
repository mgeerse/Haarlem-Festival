using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Models
{
    public class DiningViewModel
    {
        public List<Dining> DiningActivities { get; set; }
        public int SelectedItemId { get; set; }
    }
}