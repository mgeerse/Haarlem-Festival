using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Models.ViewModels
{
    public class DiningDay
    {
        public string Date { get; set; }
        public List<Dining> dinings { get; set; }
    }
}