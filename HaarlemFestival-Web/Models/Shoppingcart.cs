using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaarlemFestival_Web.Repositories;

namespace HaarlemFestival_Web.Models
{
    public class ShoppingCart
    {
        //Maarten Geerse

        public List<int> UsedIds = new List<int>();

        private TicketRepository ticketRepository = TicketRepository.instance;
        //Singleton
        public static readonly ShoppingCart UniqueInstance;

        public List<Ticket> tickets;

        static ShoppingCart()
        {
            // If the cart is not in the session, create one and put it there
            // Otherwise, get it from the session
            if (HttpContext.Current.Session["ShoppingCart"] == null)
            {
                UniqueInstance = new ShoppingCart();
                UniqueInstance.tickets = new List<Ticket>();
                HttpContext.Current.Session["ShoppingCart"] = UniqueInstance;
            }
            else
            {
                UniqueInstance = (ShoppingCart)HttpContext.Current.Session["ShoppingCart"];
            }
        }

        public int GetNewId()
        {
            if (UsedIds.Count == 0)
            {
                UsedIds.Add(0);
                return 0;
            }
            return UsedIds.Last() + 1;
        }
        public void AddTicket(Ticket ticket)
        {
            //Shoppingcart moet zijn eigen Id's bijhouden totdat deze in de database gaan.
            //In de database worden ze weggehaald en gebruikt de database haar eigen nummering hiervoor.
            ticket.Id = UsedIds.Last() + 1;

            tickets.Add(ticket);
        }

        public Ticket UpdateTicketAmount(int Id, int Amount)
        {
            Ticket ticket = tickets.Where(m => m.Id == Id).Single();
            ticket.Amount = Amount;
            return ticket;
        }

        public void RemoveTicketByObject(Ticket ticket)
        {
            tickets.Remove(ticket);
        }

        public void RemoveTicketById(int Id)
        {
            Ticket ticket = tickets.Where(m => m.Id == Id).Single();
            tickets.Remove(ticket);
        }

        public decimal GetTotal()
        {
            decimal price = 0;

            foreach (var item in tickets)
            {
                price += item.Price;
            }

            return price;
        }
    }
}