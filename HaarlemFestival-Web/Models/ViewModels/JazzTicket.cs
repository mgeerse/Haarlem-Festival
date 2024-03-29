﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Models.ViewModels
{
    public class JazzTicket
    {
        //We kunnen hierop filteren binnen de TicketController en in de TicketView
        public IEnumerable<Jazz> jazz;

        public ShoppingCart shoppingCart;

        [Display(Name = "Amount")]
        [Range(0, int.MaxValue, ErrorMessage = "Not a valid number has been given")]
        public int Amount;
    }
}