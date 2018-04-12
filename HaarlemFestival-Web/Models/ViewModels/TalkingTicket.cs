using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HaarlemFestival_Web.Models.ViewModels
{
    public class TalkingTicket
    {
        // GET: TalkingTicket
        //We kunnen hierop filteren binnen de TicketController en in de TicketView
        public IEnumerable<Talking> talking;

        //We geven ook een lijst van tickets mee.
        //Dit is nodig doordat de database geen mogelijkheid biedt tot het makkelijk berkenen van de al geboekte tickets
        public IEnumerable<Ticket> tickets;

        public int amount;
        public ShoppingCart shoppingCart;
        public bool justOrdered;
    }
}