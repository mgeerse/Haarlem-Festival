using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Models
{
    public class DiningViewModel
    {
        public List<Restaurant> Restaurants { get; set; }
        public int SelectedRestaurant { get; set; }

        public List<Dining> DiningActivities { get; set; }
        public int SelectedDiningActivity { get; set; }
    }
}