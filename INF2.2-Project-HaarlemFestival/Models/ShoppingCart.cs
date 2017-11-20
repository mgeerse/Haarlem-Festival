using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INF2._2_Project_HaarlemFestival.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; private set; }

        [ForeignKey("TicketId")]
        public List<Ticket> Tickets { get; private set; }

        public ShoppingCart(int ShoppingCartId)
        {
            this.ShoppingCartId = ShoppingCartId;
        }

        //TODO: Hier methodes om properties binnen dit object te wijzigen:
        //....
    }
}