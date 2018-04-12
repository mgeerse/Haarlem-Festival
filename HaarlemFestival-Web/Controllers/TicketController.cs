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

        private ActivityRepository activityRepository = new ActivityRepository();

        private ShoppingCart shoppingCart = ShoppingCart.UniqueInstance;

        // GET: Ticket
        public ActionResult Index()
        {
            return View("~/Views/Ticket/Index.cshtml");
        }

        public ActionResult Overview()
        {
            return View("~/Views/Ticket/Overview.cshtml", shoppingCart.tickets);
        }

        [HttpPost]
        public ActionResult EditTicket(int Id, string Option, int Amount)
        {
            switch (Option)
            {
                case "Update Amount":
                    Ticket ticket = shoppingCart.tickets.Where(m => m.Id == Id).Single();
                    ticket.Amount = Amount;
                    break;

                case "Remove Ticket":
                    shoppingCart.RemoveTicketByInt(Id);
                    break;
            }

            return Overview();
        }

        public ActionResult Jazz()
        {
            JazzTicket JazzTicket = new JazzTicket
            {
                jazz = jazzRepository.GetAll()

            };

            return View("~/Views/Ticket/Jazz.cshtml", JazzTicket);
        }

        [HttpPost]
        public ActionResult OrderJazzTicket(int Id, int Amount)
        {
            Jazz jazz = jazzRepository.GetById(Id);

            shoppingCart.AddTicket(MakeTicketFromJazzActivity(jazz, Amount));

            return Jazz();
        }

        private Ticket MakeTicketFromJazzActivity(Jazz jazz, int Amount)
        {
            Ticket ticket = new Ticket
            {
                ActivityId = jazz.Id,
                Activity = activityRepository.GetById(jazz.Id),
                Price = jazz.Price,
                Amount = Amount,
                SoldAt = DateTime.Now,
            };

            return ticketRepository.Insert(ticket);
        }
    }
}