using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaarlemFestival_Web.Repositories;
using HaarlemFestival_Web.Models;
using HaarlemFestival_Web.Models.ViewModels;
namespace HaarlemFestival_Web.Controllers
{
    public class JazzController : Controller
    {
        private JazzRepository jazzRepository = JazzRepository.Instance;

        public ActionResult Day(string Date)
        {
            if ((!DateTime.TryParse(Date, out DateTime dateTime) || jazzRepository.GetByDay(Date).Count == 0))
            {
                return View("~/Views/Pages/Jazz.cshtml", jazzRepository.GetDays());
            }
            else
            {
                JazzDay jazzDay = new JazzDay
                {
                    Jazzs = jazzRepository.GetByDay(Date),
                    Date = dateTime.DayOfWeek.ToString()
                };
                return View("~/Views/Jazz/Day.cshtml", jazzDay);
            }
        }
    }
}