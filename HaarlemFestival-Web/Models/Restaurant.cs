using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Models
{
    /// <summary>
    /// Class for separate restaurants. 
    /// Needed for proper selection dialog in ticket
    /// selection screen.
    /// </summary>
    public class Restaurant
    {
        [Key]
        public int Id { get; private set; }

        public string Name { get; set; }

        public ICollection<Location> Location { get; set; }
        public ICollection<Cuisine> Cuisines { get; set; }
    }
}