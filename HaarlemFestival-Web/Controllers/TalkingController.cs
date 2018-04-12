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
        TalkingRepository talkingRepository = new TalkingRepository();

        public ActionResult Talking()
        {
            TalkingTicket TalkingTicket = new TalkingTicket();
            TalkingTicket.talking = talkingRepository.GetAll();
            return View("~/Views/Ticket/Talking.cshtml", TalkingTicket);
        }
    }
}