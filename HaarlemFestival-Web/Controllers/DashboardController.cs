using HaarlemFestival_Web.Contexts;
using HaarlemFestival_Web.Models;
using HaarlemFestival_Web.Models.ViewModels;
using HaarlemFestival_Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaarlemFestival_Web.Controllers
{
    public class DashboardController : Controller
    {
        ActivityRepository activityRepo = new ActivityRepository();

        #region Overview
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        // GET: Dashboard
        public ActionResult TicketSalesAttendance()
        {
            return View();
        }

        // GET: Dashboard
        public ActionResult TimeTable()
        {
            return View();
        }
        #endregion

        #region Manage Event
        // GET: Dashboard
        [HttpGet]
        public ActionResult PageContent()
        {
            return View();
        }

        // GET: Dashboard
        [HttpGet]
        public ActionResult EventDetails()
        {
            EventViewModel eventViewModel = new EventViewModel();
            return View(eventViewModel);
        }

        [HttpGet]
        public ActionResult EditEvent(int id)
        {
            return View(activityRepo.GetById(id));
        }



        [HttpPost]
        public ActionResult EditEvent()
        {
            int id = int.Parse(Request.Form[1]);
            string name = Request.Form[2];
            string description = Request.Form[3];
            int capacity = int.Parse(Request.Form[4]);
            decimal price = decimal.Parse(Request.Form[5]);
            DateTime startTime = DateTime.Parse(Request.Form[6]);
            DateTime endTime = DateTime.Parse(Request.Form[7]);
            int subjectId = int.Parse(Request.Form[8]);

            switch (subjectId)
            {
                //Jazz
                case 5:
                    activityRepo.Update(id, new JazzViewModel(name, description, capacity, price, startTime, endTime, subjectId));
                    break;
                //Talking
                case 6:
                    activityRepo.Update(id, new TalkingViewModel(name, description, capacity, price, startTime, endTime, subjectId));
                    break;
                //Historic
                case 7:
                    activityRepo.Update(id, new WalkingViewModel(name, description, capacity, price, startTime, endTime, subjectId));
                    break;
                //Dining
                case 8:
                    activityRepo.Update(id, new DiningViewModel(name, description, capacity, price, startTime, endTime, subjectId));
                    break;
            }

            return RedirectToAction("EventDetails");
        }
        #endregion

        #region Account
        // GET: Dashboard
        public ActionResult PersonalInfo()
        {
            return View();
        }
        #endregion
    }
}