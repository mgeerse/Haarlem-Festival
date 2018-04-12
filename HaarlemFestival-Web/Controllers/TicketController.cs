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
        private TicketRepository ticketRepository = TicketRepository.Instance;
        private JazzRepository jazzRepository = JazzRepository.Instance;
        private DiningRepository diningRepository = DiningRepository.Instance;
        private WalkingRepository walkingRepository = WalkingRepository.Instance;
        private TalkingRepository talkingRepository = TalkingRepository.Instance;
        private ActivityRepository activityRepository = ActivityRepository.Instance;

        private ShoppingCart shoppingCart = ShoppingCart.UniqueInstance;

        // GET: Ticket
        public ActionResult Index()
        {
            return View("~/Views/Ticket/Index.cshtml");
        }

        public ActionResult Overview()
        {
            //shoppingCart = ShoppingCart.UniqueInstance;
            return View("~/Views/Ticket/Overview.cshtml", shoppingCart);
        }

        [HttpPost]
        public ActionResult EditTicket(int TicketId, int Amount, string submit)
        {
            //Id is hier de Id van de activiteit
            switch (submit)
            {
                case "Update Amount":
                    shoppingCart.UpdateTicketAmount(TicketId, Amount);
                    break;

                case "Remove Ticket":
                    shoppingCart.RemoveTicketById(TicketId);
                    break;
            }

            return Overview();
        }

        public ActionResult Jazz()
        {
            JazzTicket JazzTicket = new JazzTicket();

            JazzTicket.jazz = jazzRepository.GetAll();
            JazzTicket.shoppingCart = ShoppingCart.UniqueInstance;

            return View("~/Views/Ticket/Jazz.cshtml", JazzTicket);
        }

        [HttpPost]
        public ActionResult OrderJazzTicket(int Id, int Amount)
        {
            Jazz jazz = jazzRepository.GetById(Id);
            Ticket ticket = CreateTicketFromJazzActivity(jazz, Amount);

            shoppingCart.AddTicket(ticket);
            return Jazz();
        }

        private Ticket CreateTicketFromJazzActivity(Jazz jazz, int Amount)
        {
            Ticket ticket = new Ticket();
            ticket.Id = shoppingCart.GetNewId();
            ticket.ActivityId = jazz.Id;
            ticket.Activity = activityRepository.GetById(jazz.Id);
            ticket.Price = jazz.Price;
            ticket.Amount = Amount;
            ticket.SoldAt = DateTime.Now;

            return ticket;
        }
    }
}