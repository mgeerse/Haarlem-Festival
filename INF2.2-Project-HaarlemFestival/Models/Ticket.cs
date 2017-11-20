using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INF2._2_Project_HaarlemFestival.Models
{
    public class Ticket
    {
        public int TicketId { get; private set; }
        public decimal Price { get; private set; }
        public int Amount { get; private set; }

        //Constructor:
        public Ticket(int TicketId, decimal Price, int Amount)
        {
            this.TicketId = TicketId;
            this.Price = Price;
            this.Amount = Amount;
        }

        //TODO: Hier methodes om properties binnen dit object te wijzigen:
        //....
    }
}