using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; private set; }

        // Non-referencing properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        // Referencing properties
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}