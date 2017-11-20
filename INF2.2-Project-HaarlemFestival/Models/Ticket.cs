using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace INF2._2_Project_HaarlemFestival.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; private set; }
        public decimal Price { get; private set; }
        public int Amount { get; private set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; private set; }

        [ForeignKey("ShoppingCartId")]
        public ShoppingCart ShoppingCart { get; private set; }

        [ForeignKey("ActivityId")]
        public Activity Activity { get; private set; }
        
        //Constructor:
        public Ticket(int TicketId, decimal Price, int Amount, Customer Customer, ShoppingCart ShoppingCart, Activity Activity)
        {
            this.TicketId = TicketId;
            this.Price = Price;
            this.Amount = Amount;
            this.Customer = Customer;
            this.ShoppingCart = ShoppingCart;
            this.Activity = Activity;
        }

        //TODO: Hier methodes om properties binnen dit object te wijzigen:
        //....
    }
}