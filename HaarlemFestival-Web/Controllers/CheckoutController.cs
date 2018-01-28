using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaarlemFestival_Web.Models;
using HaarlemFestival_Web.Repositories;

namespace HaarlemFestival_Web.Controllers
{

    public class CheckoutController : Controller
    {

        private WalkingRepository walkingRepository = new WalkingRepository();
        private DiningRepository diningRepository = new DiningRepository();
        private JazzRepository jazzRepository = new JazzRepository();
        private TalkingRepository talkingRepository = new TalkingRepository();

        /// <summary>
        /// GET: /Checkout/
        /// 
        /// Redirects the user to /Checkout/Choose by default.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return RedirectToAction("Choose");
        }

        #region Separate pages for the ticket system

        /// <summary>
        /// GET: /Checkout/Choose/
        /// 
        /// Returns the user to the Choose page. This page allows users
        /// to add tickets to their shopping cart. 
        /// </summary>
        /// <returns></returns>
        public ActionResult Choose()
        {
            return View();
        }

        /// <summary>
        /// GET: /Checkout/Buy
        /// 
        /// Returns the purchasing page where customers fill in their
        /// customer data and get redirected to the payment page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Buy()
        {
            return View();
        }

        /// <summary>
        /// GET: /Checkout/Thanks
        /// 
        /// Returns the "Thank You" page. This page tells the customer
        /// that their order has passed through correctly and allows
        /// them to return to the website. 
        /// </summary>
        /// <returns></returns>
        public ActionResult Thanks()
        {
            return View();
        }

        #endregion

        #region Choosepage partial view rendering

        public ActionResult PartialDining()
        {
            DiningViewModel model = new DiningViewModel()
            {
                DiningActivities = diningRepository.GetAll().ToList(),
                SelectedItemId = 0
            };
            return PartialView("_Dining", model);
        }

        public List<Dining> GetTimeslotsForActivity(int id)
        {
            return diningRepository.GetAll().Where(m => m.Id == id).ToList();
        }

        #endregion

    }
}