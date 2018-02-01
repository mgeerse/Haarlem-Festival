using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Models
{
    public class JazzViewModel
    {
        public int SelectedDay { get; set; }

        public List<Jazz> JazzActivities { get; set; }
        public int SelectedJazzActivity { get; set; }
    }
}