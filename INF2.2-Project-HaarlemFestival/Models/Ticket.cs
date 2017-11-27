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
        public int TicketId { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [ForeignKey("ShoppingCartId")]
        public ShoppingCart ShoppingCart { get; set; }

        [ForeignKey("ActivityId")]
        public Activity Activity { get; set; }

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