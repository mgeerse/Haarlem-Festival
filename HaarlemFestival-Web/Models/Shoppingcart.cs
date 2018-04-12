using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Models
{
    public class ShoppingCart
    {
        //Maarten Geerse

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
        }

        public void RemoveTicket(Ticket ticket)
        {
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