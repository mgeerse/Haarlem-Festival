using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace INF2._2_Project_HaarlemFestival.Models
{
    public class ShoppingCart
    {
        [Key]
        public int ShoppingCartId { get; set; }

        [ForeignKey("TicketId")]
        public virtual ICollection<Ticket> Tickets { get; set; }

        public ShoppingCart(int ShoppingCartId, ICollection<Ticket> Tickets)
        {
            this.ShoppingCartId = ShoppingCartId;
            this.Tickets = Tickets;
        }

        //TODO: Hier methodes om properties binnen dit object te wijzigen:
        //....
    }
}