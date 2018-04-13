using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HaarlemFestival_Web.Models.ViewModels
{
    public class TalkingTicket
    {
        // GET: TalkingTicket
        //We kunnen hierop filteren binnen de TicketController en in de TicketView
        public IEnumerable<Talking> Talking;

        //We geven ook een lijst van tickets mee.
        //Dit is nodig doordat de database geen mogelijkheid biedt tot het makkelijk berkenen van de al geboekte tickets
        public IEnumerable<Ticket> Tickets;

        [Display(Name = "Amount")]
        [Range(0, int.MaxValue, ErrorMessage = "Not a valid number has been given")]
        public int Amount;
        public string Comment;
        public ShoppingCart ShoppingCart;
        public bool JustOrdered;
    }
}