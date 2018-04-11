using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HaarlemFestival_Web.Models
{
    public class Location
    {
        [Key]
        public int Id { get; private set; }
        public string Street { get; set; }
        public string Postalcode { get; set; }
        public string Name { get; set; }
        
        public virtual Restaurant Restaurant { get; set; }
    }
}