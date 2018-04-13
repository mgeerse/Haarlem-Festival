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
        JazzRepository jazzRepo = new JazzRepository();
        DiningRepository diningRepo = new DiningRepository();
        WalkingRepository walkingRepo = new WalkingRepository();
        IntervieweeRepository intervieweeRepo = new IntervieweeRepository();
        SubjectRepository subjectRepo = new SubjectRepository();

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

        #region Manage Activities
        // GET: Dashboard
        [HttpGet]
        public ActionResult PageContent()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ActivityDetails()
        {
            EventViewModel activityViewModel = new EventViewModel();
            return View(activityViewModel);
        }

        [HttpGet]
        public ActionResult CreateActivity()
        {
            return View("CreateActivity");
        }

        [HttpPost]
        public ActionResult CreateActivity(int i = 0)
        {
            DateTime startTime = new DateTime();
            DateTime endTime = new DateTime();

            string name = Request.Form[1];
            string description = Request.Form[2];
            int capacity = int.Parse(Request.Form[3]);
            decimal price = decimal.Parse(Request.Form[4]);
            if (DateTime.TryParse(Request.Form[5].ToString(), out DateTime resultStartTime))
            {
                startTime = resultStartTime;
            }
            if (DateTime.TryParse(Request.Form[6].ToString(), out DateTime resultEndTime))
            {
                endTime = resultEndTime;
            }
            int subjectId = int.Parse(Request.Form[7]);

            switch (subjectId)
            {
                //Jazz
                case 5:
                    Jazz jazz = new Jazz { Name = name, Description = description, Capacity = capacity, Price = price, StartTime = startTime, EndTime = endTime, SubjectId = subjectId, LocationId = 21 };
                    activityRepo.Insert(jazz);
                    break;

                //Talking
                case 6:
                    Talking talking = new Talking { Name = name, Description = description, Capacity = capacity, Price = price, StartTime = startTime, EndTime = endTime, SubjectId = subjectId, LocationId = 22 };
                    activityRepo.Insert(talking);
                    break;

                //Historic
                case 7:
                    Walking walking = new Walking { Name = name, Description = description, Capacity = capacity, Price = price, StartTime = startTime, EndTime = endTime, SubjectId = subjectId, LocationId = 23 };
                    activityRepo.Insert(walking);
                    break;

                //Dining
                case 8:
                    Dining dining = new Dining { Name = name, Description = description, Capacity = capacity, Price = price, StartTime = startTime, EndTime = endTime, SubjectId = subjectId, LocationId = 24 };
                    activityRepo.Insert(dining);
                    break;
            }

            return RedirectToAction("ActivityDetails");
        }

        [HttpGet]
        public ActionResult EditActivity(int id)
        {
            return View(activityRepo.GetById(id));
        }

        [HttpPost]
        public ActionResult EditActivity()
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

            return RedirectToAction("ActivityDetails");
        }

        [HttpGet]
        public ActionResult RemoveActivity(int id)
        {
            activityRepo.Delete(activityRepo.GetById(id));

            return RedirectToAction("ActivityDetails");
        }
        #endregion

        #region Manage Main Events
            #region Talking
            [HttpGet]
            public ActionResult EditTalking()
            {
                List<Interviewee> intervieweeList = intervieweeRepo.GetAllInterviewees();

                return View(intervieweeList);
            }

            [HttpGet]
            public ActionResult EditInterviewee(int id)
            {
                return View(intervieweeRepo.GetById(id));
            }

            [HttpPost]
            public ActionResult EditInterviewee()
            {
                int id = int.Parse(Request.Form[1].ToString());
                string name = Request.Form[2].ToString();
                string description = Request.Form[3].ToString();

                intervieweeRepo.Update(id, new IntervieweeViewModel(name, description));

                return RedirectToAction("EditTalking");
            }

            #endregion

            #region Jazz
            [HttpGet]
            public ActionResult EditJazz(int id)
            {
                return View(subjectRepo.GetById(id));
            }

            [HttpPost]
            public ActionResult EditJazz()
            {
                int id = int.Parse(Request.Form[1].ToString());
                string name = Request.Form[2].ToString();
                string description = Request.Form[3].ToString();

                subjectRepo.Update(id, new SubjectViewModel(name, description));

                return RedirectToAction("EditJazz");
            }
            #endregion

            #region Dining
            [HttpGet]
            public ActionResult EditDining(int id)
            {
                Subject s = subjectRepo.GetById(id);
                return View(new SubjectViewModel(s.Name, s.Description));
            }

            [HttpPost]
            public ActionResult EditDining()
            {
                int id = int.Parse(Request.Form[1].ToString());
                string name = Request.Form[2].ToString();
                string description = Request.Form[3].ToString();

                subjectRepo.Update(id, new SubjectViewModel(name, description));

                return RedirectToAction("EditDining");
            }
            #endregion

            #region Walking
            [HttpGet]
            public ActionResult EditWalking(int id)
            {
                Subject s = subjectRepo.GetById(id);
                return View(new SubjectViewModel(s.Name, s.Description));
            }

            [HttpPost]
            public ActionResult EditWalking()
            {
                int id = int.Parse(Request.Form[1].ToString());
                string name = Request.Form[2].ToString();
                string description = Request.Form[3].ToString();

                subjectRepo.Update(id, new SubjectViewModel(name, description));

                return RedirectToAction("EditWalking");
            }
            #endregion
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