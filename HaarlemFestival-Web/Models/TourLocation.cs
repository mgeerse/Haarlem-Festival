using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HaarlemFestival_Web.Models
{
    public class TourLocation
    {
        [Key]
        public int Id { get; private set; }


        public string Street { get; set; }
        public int Number { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


    }
}