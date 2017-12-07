using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaarlemFestival_Web.Models
{
    [Table("Dining")]
    public class Dining : Activity
    {
        public Cuisine Cuisine { get; set; }
        public int AmountOfSessions { get; set; }
        public TimeSpan SessionLength { get; set; }
    }
}