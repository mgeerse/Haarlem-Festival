using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaarlemFestival_Web.Contexts;

namespace HaarlemFestival_Web.Controllers
{
    public class HomeController : Controller
    {
        private FestivalContext FestivalContext = new FestivalContext();

        public ActionResult Index()
        {
            return View(FestivalContext.Subjects.ToList());
        }
    }
}