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
            // TODO Create repositories for the different activities

            // The reason these all are in different lists is because 
            // everything currently is bound to the same page. On the
            // order page, the different buttons load different HTML5
            // <template>s into the order field. We need every activity
            // separately, because we want them usable for the templates
            // that they belong to.
            ActivityListsViewModel model = new ActivityListsViewModel()
            {
                WalkingActivities = walkingRepository.GetAll(),
                TalkingActivities = talkingRepository.GetAll(),
                DiningActivities = diningRepository.GetAll(),
                JazzActivities = jazzRepository.GetAll()
            };

            return View(model);
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

    }
}