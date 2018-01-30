using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult Dining()
        {
            return View();
        }

        public ActionResult Jazz()
        {
            return View();
        }

        public ActionResult Talking()
        {
            return View();
        }

        #endregion


    }
}