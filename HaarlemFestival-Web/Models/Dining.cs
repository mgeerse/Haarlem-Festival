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
        public Restaurant Restaurant { get; set; }
    }
}