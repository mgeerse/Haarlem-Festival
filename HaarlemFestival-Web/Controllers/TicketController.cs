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

            smtpClient.Credentials = new System.Net.NetworkCredential("mgeerse@hotmail.com", "wachtwoordmaarverborgenhe;)");
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
            catch (Exception) // NV 4-13-18: Je kunt ook catchen zonder exception of exception variabele.
            {
                //niets
            }
            //Genoeg gehad met de lol.
            //Nu de gegevens van tickets uit shoppingCart sturen naar de database!


            //FIX ME / FIXME:
            //Crash bij het toevoegen van een ticket EN customer in de database!
            //Error-code:
            //An entity object cannot be referenced by multiple instances of IEntityChangeTracker.
            //
            //Het heeft er mee te maken dat Ticket door meerdere contexten wordt gevolgd, zoals in JazzRepository.context, customerRepository.context
            //en ook ActivityRepository.context.
            //
            //Meer informatie:
            //
            //https://stackoverflow.com/questions/10191734/entity-object-cannot-be-referenced-by-multiple-instances-of-ientitychangetracker?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
            //
            //I am so fucked



            //foreach (var item in shoppingCart.tickets)
            //{
            //    ticketRepository.Insert(item);
            //}

            //En dan nog de customer in de database zetten
            //Customer customer = new Customer
            //{
            //    FirstName = Firstname,
            //    LastName = Sirname,
            //    EmailAddress = Email,
            //    Tickets = shoppingCart.tickets
            //};

            //customerRepository.Insert(customer);

            return View("~/Views/Ticket/Thanks");
        }

        public ActionResult Jazz()
        {
            JazzTicket JazzTicket = new JazzTicket();

            JazzTicket.jazz = jazzRepository.GetAll();
            JazzTicket.shoppingCart = ShoppingCart.UniqueInstance;

            return View("~/Views/Ticket/Jazz.cshtml", JazzTicket);
        }

        public ActionResult Dining()
        {
            DiningTicket diningTicket = new DiningTicket();

            diningTicket.dining = diningRepository.GetAll();
            diningTicket.shoppingCart = ShoppingCart.UniqueInstance;

            return View("~/Views/Ticket/Dining.cshtml", diningTicket);
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

        [HttpPost]
        public ActionResult OrderDiningTicket(int id, int amount)
        {
            Dining dining = diningRepository.GetById(id);
            Ticket ticket = CreateTicketFromActivity(dining, amount);

            if (amount != 0)
            {
                shoppingCart.AddTicket(ticket);
            }
            else
            {
                ModelState.AddModelError("Please set a correct amount.", new ArgumentException("Incorrect ticket amount"));
            }

            return Dining();
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

        private Ticket CreateTicketFromActivity(Activity activity, int amount)
        {
            Ticket ticket = new Ticket();
            ticket.Id = shoppingCart.GetNewId();
            ticket.ActivityId = activity.Id;
            ticket.Activity = activityRepository.GetById(activity.Id);
            ticket.Price = activity.Price;
            ticket.Amount = amount;
            ticket.SoldAt = DateTime.Now;

            return ticket;
        }

        public ActionResult Talking()
        {
            TalkingTicket TalkingTicket = new TalkingTicket();

            TalkingTicket.Talking = talkingRepository.GetAll();
            TalkingTicket.ShoppingCart = ShoppingCart.UniqueInstance;

            return View("~/Views/Ticket/Talking.cshtml", TalkingTicket);
        }

        [HttpPost]
        public ActionResult OrderTalkingTicket(int Id, int Amount, string Comment)
        {
            TalkingController talkingController = new TalkingController();
            talkingController.maxTickets(Amount);
            Talking talking = talkingRepository.GetById(Id);
            shoppingCart.AddTicket(MakeTicketFromTalkingActivity(talking, Amount, Comment));
            return Talking();
        }

        private Ticket MakeTicketFromTalkingActivity(Talking Talking, int Amount, string Comment)
        {
            return new Ticket
            {
                ActivityId = Talking.Id,
                Activity = activityRepository.GetById(Talking.Id),
                Price = Talking.Price,
                Amount = Amount,
                Comment = Comment,
                SoldAt = DateTime.Now,
            };
        }
    }
}