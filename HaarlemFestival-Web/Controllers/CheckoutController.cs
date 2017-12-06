using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaarlemFestival_Web.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Index()
        {
            return RedirectToAction("Choose");
        }

        public ActionResult Choose()
        {
            return View();
        }

        public ActionResult Buy()
        {
            return View();
        }

        public ActionResult Thanks()
        {
            return View();
        }
    }
}