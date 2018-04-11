using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Models.ViewModels
{
    public class AvailableTicket
    {
        //We kunnen hierop filteren binnen de TicketController en in de TicketView
        public IEnumerable<Jazz> jazz;
        public IEnumerable<Dining> dining;
        public IEnumerable<Walking> walking;
        public IEnumerable<Talking> talking;

        //We geven ook een lijst van tickets mee.
        //Dit is nodig doordat de database geen mogelijkheid biedt tot het makkelijk berkenen van de al geboekte tickets
        public IEnumerable<Ticket> tickets;

        public int amountToOrder;
        public string Option;
    }
}