using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaarlemFestival_Web.Models;

namespace HaarlemFestival_Web.Controllers
{
    /// <summary>
    /// This controller handles all pages that have to do with showing
    /// logic of the ordering page. This page contains logic for putting
    /// tickets into your basket, ordering those tickets and sending
    /// the tickets to your mail address.
    /// </summary>
    public class CheckoutController : Controller
    {
        
        /// <summary>
        /// Redirects the user to the Choose page if they visit /buy/ .
        /// Useful if we have users that know what they want to visit,
        /// and don't want to go through the information on the homepage
        /// to get where they want to get.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return RedirectToAction("Choose");
        }

        /// <summary>
        /// Shows the choosing page of the website. This website
        /// contains the logic for picking a ticket and adding one
        /// to the shopping cart of the user.
        /// </summary>
        /// <returns></returns>
        public ActionResult Choose()
        {
            return View();
        }

        /// <summary>
        /// Shows the ordering page of the website. Contains fields for
        /// entering customer data. 
        /// </summary>
        /// <param name="tickets">List of tickets that the user selected.</param>
        /// <returns></returns>
        public ActionResult Buy(ICollection<Ticket> tickets)
        {
            return View(tickets);
        }

        /// <summary>
        /// Shows a generic "Thank you" screen to the user after completing
        /// an order.
        /// </summary>
        /// <returns></returns>
        public ActionResult Thanks()
        {
            return View();
        }
    }
}