using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Models.ViewModels
{
    public class DiningTicket
    {
        public IEnumerable<Dining> dining;

        public ShoppingCart shoppingCart;

        [Display(Name = "Amount")]
        [Range(0, int.MaxValue, ErrorMessage = "Not a valid number has been given")]
        public int amount;
    }
}