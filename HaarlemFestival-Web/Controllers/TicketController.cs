using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaarlemFestival_Web.Repositories;
using HaarlemFestival_Web.Models.ViewModels;
using HaarlemFestival_Web.Models;
using System.Net.Mail;
using System.Text;

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
        private CustomerRepository customerRepository = CustomerRepository.Instance;

        private ShoppingCart shoppingCart = ShoppingCart.UniqueInstance;

        // GET: Ticket
        public ActionResult Index()
        {
            return View("~/Views/Ticket/Index.cshtml");
        }

        public ActionResult Buy()
        {
            TicketRegisterViewModel ticketRegisterViewModel = new TicketRegisterViewModel();

            return View("~/Views/Ticket/Buy.cshtml", ticketRegisterViewModel);
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
                    if (Amount != 0)
                    {
                        shoppingCart.UpdateTicketAmount(TicketId, Amount);
                    }
                    else
                    {
                        ModelState.AddModelError("Error!", "You must set the amount higher than 0 before updating your basket.");
                    }
                    break;

                case "Remove Ticket":
                    shoppingCart.RemoveTicketById(TicketId);
                    break;
            }

            return Overview();
        }

        [HttpPost]
        public ActionResult Register(string Firstname, string Sirname, string Email)
        {
            //Send mail
            SmtpClient smtpClient = new SmtpClient("smtp.live.com", 25);

            smtpClient.Credentials = new System.Net.NetworkCredential("mgeerse@hotmail.com", "1koolland&");
            smtpClient.UseDefaultCredentials = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            smtpClient.Host = "smtp.hotmail.com";
            smtpClient.Port = 25;
            MailMessage mail = new MailMessage();

            mail.Body += "Dear " + Firstname + " " + Sirname + ",";

            StringBuilder sb = new StringBuilder();
            foreach (var item in shoppingCart.tickets)
            {
                sb.Append("Activity: " + item.Activity.Name + "\n");
                sb.Append("Starting from " + item.Activity.StartTime.ToShortDateString().ToString() + " unitll " + item.Activity.EndTime.ToShortDateString() + "on " + item.Activity.StartTime.ToShortDateString() + "\n");
                sb.Append("You're expected at:" + item.Activity.Location);
                sb.Append("\n\n");
            };

            mail.Body += sb.ToString();

            //Setting From , To and CC
            mail.From = new MailAddress("mgeerse@hotmail.com", "Haarlem Festival Tickets");
            mail.To.Add(new MailAddress(Email));

            try
            {
                //Dit lagde eerder uit-
                smtpClient.Send(mail);
            }
            catch (Exception e)
            {
                //niets
            }
            //Genoeg gehad met de lol.
            //Nu de gegevens van tickets uit shoppingCart sturen naar de database!


            //En dan nog de customer in de database zetten
            Customer customer = new Customer
            {
                FirstName = Firstname,
                LastName = Sirname,
                EmailAddress = Email,
                Tickets = shoppingCart.tickets
            };

            customerRepository.Insert(customer);

            List<Ticket> customerTickets = shoppingCart.tickets;
            List<Ticket> escape = new List<Ticket>();
            foreach (var item in customerTickets)
            {
                Ticket ticket = item;
                escape.Add(ticket);
            }


            return View("~/Views/Ticket/Thanks");
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

            if (Amount != 0)
            {
                shoppingCart.AddTicket(ticket);
            }
            else
            {
                ModelState.AddModelError("Error!", "You must set the amount before adding it to your basket.");
            }

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