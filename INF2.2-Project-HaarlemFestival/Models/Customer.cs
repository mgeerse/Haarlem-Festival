using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INF2._2_Project_HaarlemFestival.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Country { get; set; }

        [ForeignKey("TicketId")]
        public virtual ICollection<Ticket> Tickets { get; set; }

        //Constructor:
        public Customer(int CustomerId, string FirstName, string LastName, string Address, string EmailAddress, string Country, ICollection<Ticket> Tickets)
        {
            this.CustomerId = CustomerId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.EmailAddress = EmailAddress;
            this.Country = Country;
            this.Tickets = Tickets;
        }

        //TODO: Hier methodes om properties binnen dit object te wijzigen:
        //....
    }
}