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
            return new Ticket
            {
                ActivityId = jazz.Id,
                Activity = activityRepository.GetById(jazz.Id),
                Price = jazz.Price,
                Amount = Amount,
                SoldAt = DateTime.Now,
            };
        }

        public ActionResult Talking()
        {
            TalkingTicket TalkingTicket = new TalkingTicket
            {
                talking = talkingRepository.GetAll()
            };
            return View("~/Views/Ticket/Talking.cshtml", TalkingTicket);
        }

        [HttpPost]
        public ActionResult OrderTalkingTicket(int Id, int amount, string comment)
        {
            Talking talking = talkingRepository.GetById(Id);
            shoppingCart.AddTicket(MakeTicketFromTalkingActivity(talking, amount, comment));
            return Talking();
        }

        private Ticket MakeTicketFromTalkingActivity(Talking talking, int amount, string comment)
        {
            return new Ticket
            {
                ActivityId = talking.Id,
                Activity = activityRepository.GetById(talking.Id),
                Price = talking.Price,
                Amount = amount,
                Comment = comment,
                SoldAt = DateTime.Now,
            };
        }
    }
}