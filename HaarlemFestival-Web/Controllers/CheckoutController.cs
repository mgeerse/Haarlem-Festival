using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaarlemFestival_Web.Models;
using HaarlemFestival_Web.Repositories;
using Newtonsoft.Json;

namespace HaarlemFestival_Web.Controllers
{

    public class CheckoutController : Controller
    {

        private RestaurantRepository restaurantRepository = new RestaurantRepository();

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
                Restaurants = restaurantRepository.GetAll().ToList(),
                SelectedRestaurant = 0,
                DiningActivities = diningRepository.GetAll().ToList(),
                SelectedDiningActivity = 0
            };
            return PartialView("_Dining", model);
        }

        public ActionResult GetRestaurants()
        {
            return Json(restaurantRepository.GetAll().ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetActivitiesForRestaurant(int restaurantId = 0)
        {
            List<Dining> diningActivities = diningRepository.GetAll().ToList();
            if(restaurantId != 0)
            {
                diningActivities = diningActivities.Where(m => m.Restaurant.Id == restaurantId).ToList();
            }
            var list = JsonConvert.SerializeObject(diningActivities,
            Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            return Content(list, "application/json");
        }

        #endregion

    }
}