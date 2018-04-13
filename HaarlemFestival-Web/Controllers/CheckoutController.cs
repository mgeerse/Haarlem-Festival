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

        private RestaurantRepository restaurantRepository = RestaurantRepository.Instance;

        private WalkingRepository walkingRepository = WalkingRepository.Instance;
        private DiningRepository diningRepository = DiningRepository.Instance;
        private JazzRepository jazzRepository = JazzRepository.Instance;
        private TalkingRepository talkingRepository = TalkingRepository.Instance;

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

        public ActionResult PartialWalking()
        {
            return PartialView("_Walking");
        }

        public ActionResult PartialDining()
        {
            return PartialView("_Dining");
        }

        public ActionResult PartialJazz()
        {
            return PartialView("_Jazz");
        }

        public ActionResult PartialTalking()
        {
            return PartialView("_Talking");
        }

        public ActionResult GetWalkingActivities()
        {
            return Json(walkingRepository.GetAll().ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetWalkingTimes(int walkingDay = 0)
        {
            List<Walking> walkingActivities = walkingRepository.GetAll().ToList();
            switch (walkingDay)
            {
                case 1:
                    walkingActivities = walkingActivities.Where(m => m.StartTime.DayOfWeek == DayOfWeek.Thursday).ToList();
                    break;
                case 2:
                    walkingActivities = walkingActivities.Where(m => m.StartTime.DayOfWeek == DayOfWeek.Friday).ToList();
                    break;
                case 3:
                    walkingActivities = walkingActivities.Where(m => m.StartTime.DayOfWeek == DayOfWeek.Saturday).ToList();
                    break;
            }
            var list = JsonConvert.SerializeObject(walkingActivities,
                Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            return Content(list, "application/json");
        }

        public ActionResult GetRestaurants()
        {
            return Json(restaurantRepository.GetAll().ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetActivitiesForRestaurant(int restaurantId = 0)
        {
            List<Dining> diningActivities = diningRepository.GetAll().ToList();
            if (restaurantId != 0)
            {
                diningActivities = diningActivities.Where(m => m.Restaurant.Id == restaurantId).ToList();
            }
            var list = JsonConvert.SerializeObject(diningActivities,
                Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            return Content(list, "application/json");
        }

        public ActionResult GetJazzDays()
        {
            return Json(jazzRepository.GetAll().ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetJazzBandsForDay(int day = 0)
        {
            List<Jazz> jazzActivities = jazzRepository.GetAll().ToList();
            switch (day)
            {
                case 0:
                    jazzActivities = jazzActivities.Where(m => m.StartTime.DayOfWeek == DayOfWeek.Thursday).ToList();
                    break;
                case 1:
                    jazzActivities = jazzActivities.Where(m => m.StartTime.DayOfWeek == DayOfWeek.Friday).ToList();
                    break;
                case 2:
                    jazzActivities = jazzActivities.Where(m => m.StartTime.DayOfWeek == DayOfWeek.Saturday).ToList();
                    break;
            }
            var list = JsonConvert.SerializeObject(jazzActivities,
                Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            return Content(list, "application/json");
        }

        public ActionResult GetTalking()
        {
            return Json(talkingRepository.GetAll().ToList(), JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}