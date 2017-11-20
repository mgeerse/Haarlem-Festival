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
        public int CustomerId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string EmailAddress { get; private set; }
        public string Country { get; private set; }

        [ForeignKey("TicketId")]
        public virtual ICollection<Ticket> Tickets { get; private set; }

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