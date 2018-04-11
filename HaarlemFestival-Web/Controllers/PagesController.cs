using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaarlemFestival_Web.Repositories;
using HaarlemFestival_Web.Models;

namespace HaarlemFestival_Web.Controllers
{
    /// <summary>
    /// Controller for all of the event detail pages.
    /// </summary>
    public class PagesController : Controller
    {
        /*
         * Returns the user to the Homepage if no specific page is selected.
         */

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        #region View returns for the other pages

        public ActionResult Historic()
        {
            return View();
        }

        private DiningRepository diningRepository = new DiningRepository();

        public ActionResult Dining()
        {
            IEnumerable<Dining> information = diningRepository.GetAll();
            return View(information);
        }

        private JazzRepository jazzRepository = new JazzRepository();

        public ActionResult Jazz()
        {
            //Geef de verschillende dagen mee naar de view.
            List<string> Days = jazzRepository.GetDays();
            return View(Days);
        }

        private TalkingRepository talkingRepository = new TalkingRepository();

        public ActionResult Talking()
        {
            IEnumerable<Talking> information = talkingRepository.GetAll().ToList();
            return View(information);
        }

        #endregion
    }
}