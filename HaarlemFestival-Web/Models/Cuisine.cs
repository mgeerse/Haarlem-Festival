using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HaarlemFestival_Web.Models
{
    [Table("Cuisine")]
    public class Cuisine
    {
        [Key]
        public int Id { get; private set; }


        public string Name { get; set; }


        public ICollection<Restaurant> Restaurants { get; set; }
    }
}