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



        private TicketRepository ticketRepository = new TicketRepository();
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

        public void AddTicket(Ticket ticket)
        {
            tickets.Add(ticket);
            ticketRepository.Insert(ticket);
        }

        public void RemoveTicketByObject(Ticket ticket)
        {
            tickets.Remove(ticket);
            ticketRepository.Delete(ticket);
        }

        public void RemoveTicketByInt(int Id)
        {
            Ticket ticket = tickets.Where(m => m.Id == Id).Single();
            tickets.Remove(ticket);
            ticketRepository.Delete(ticket);
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