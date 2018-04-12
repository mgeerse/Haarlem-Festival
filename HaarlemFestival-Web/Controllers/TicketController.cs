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

        private ShoppingCart shoppingCart = new ShoppingCart();

        // GET: Ticket
        public ActionResult Index()
        {
            return View("~/Views/Ticket/Index.cshtml");
        }


        public ActionResult Jazz()
        {
            JazzTicket JazzTicket = new JazzTicket
            {
                jazz = jazzRepository.GetAll()
            };

            //Er moet een tickets left gemaakt worden
            //Bij elke bestelling moet er in de database {amount} van de capacity af gaan

            return View("~/Views/Ticket/Jazz.cshtml", JazzTicket);
        }

        [HttpPost]
        public ActionResult OrderJazzTicket(int Id, int Amount)
        {
            Jazz jazz = jazzRepository.GetById(Id);

            shoppingCart.AddTicket(MakeTicketFromJazzActivity(jazz, Amount));

            return View("~/Views/Home/Index.cshtml");
        }

        private Ticket MakeTicketFromJazzActivity(Jazz jazz, int Amount)
        {
            return new Ticket
            {
                Price = jazz.Price,
                Amount = Amount,
                SoldAt = DateTime.Now,
            };
        }
    }
}