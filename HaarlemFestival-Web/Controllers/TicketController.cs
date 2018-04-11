using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaarlemFestival_Web.Controllers
{
    public class TicketController : Controller
    {
        private TicketController ticketController = new TicketController();
        // GET: Ticket
        public ActionResult Index()
        {

            return View("~/Views/Ticket/Buy.cshtml");
        }

    }
}