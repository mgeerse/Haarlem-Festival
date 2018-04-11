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
        JazzRepository jazzRepository = new JazzRepository();

        public ActionResult Day(string Date)
        {
            DateTime dateTime = DateTime.Parse(Date);

            JazzDay jazzDay = new JazzDay
            {
                Jazzs = jazzRepository.GetByDay(Date),
                Date = dateTime.DayOfWeek.ToString()
            };

            return View("~/Views/Jazz/Day.cshtml", jazzDay);
        }
    }
}