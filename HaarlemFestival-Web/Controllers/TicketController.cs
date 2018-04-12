using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaarlemFestival_Web.Repositories;
using HaarlemFestival_Web.Models.ViewModels;
using HaarlemFestival_Web.Models;
namespace HaarlemFestival_Web.Controllers
{
    public class TicketController : Controller
    {
        private TicketRepository ticketRepository = new TicketRepository();

        private JazzRepository jazzRepository = new JazzRepository();
        private DiningRepository diningRepository = new DiningRepository();
        private WalkingRepository walkingRepository = new WalkingRepository();
        private TalkingRepository talkingRepository = new TalkingRepository();

        // GET: Ticket
        public ActionResult Index()
        {
            AvailableTicket availableTicket = new AvailableTicket
            {
                jazz = jazzRepository.GetAll(),
                dining = diningRepository.GetAll(),
                talking = talkingRepository.GetAll(),
                walking = walkingRepository.GetAll()
            };

            //Er moet een tickets left gemaakt worden
            //Bij elke bestelling moet er in de database {amount} van de capacity af gaan

            return View("~/Views/Ticket/Index.cshtml", availableTicket);
        }
    }
}