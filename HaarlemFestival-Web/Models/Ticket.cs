using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        // Non-referencing properties
        public decimal Price { get; set; }
        // Holds the amount of people that can make use of this ticket.
        public int Amount { get; set; }
        // Holds comments for the activity, for example questions for Talking Haarlem.
        public string Comment { get; set; }

        // Referencing properties
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}