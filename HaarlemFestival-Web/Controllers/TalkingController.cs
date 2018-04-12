using System;
using System.Collections.Generic;
using System.Linq;
using HaarlemFestival_Web.Repositories;
using HaarlemFestival_Web.Models.ViewModels;
using System.Web.Mvc;

namespace HaarlemFestival_Web.Controllers
{
    public class TalkingController : Controller
    {
        TalkingTicket talking = new TalkingTicket();

        public ActionResult maxTickets()
        {
            int maxNumerOfTickets = 0;

            if (maxNumerOfTickets <= 2)
            {
                return View("~/Views/Ticket/Talking.cshtml", talking);
            }
            else
            {
                ViewBag.ErrorMessage = "You can order a maximum of two tickets per day";
                return View("~/Views/Ticket/Talking.cshtml", talking);
            }
        }
    }
}