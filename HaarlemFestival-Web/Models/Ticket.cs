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

        // Referencing properties
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}