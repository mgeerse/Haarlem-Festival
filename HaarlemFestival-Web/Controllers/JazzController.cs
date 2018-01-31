using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaarlemFestival_Web.Repositories;
using HaarlemFestival_Web.Models;

namespace HaarlemFestival_Web.Controllers
{ 
    public class JazzController : Controller
    {
        JazzRepository JR = new JazzRepository();
        
        public ActionResult Thursday()
        {
            List<Jazz> list = JR.GetByDay("Thursday");

            if (list.Count != 0)
            {
                return View(list);
            }
            else
            {
                //De dag heeft geen inhoud
                return View("~/Views/Pages/Jazz");
            }
        }

        public ActionResult Friday()
        {
            List<Jazz> list = JR.GetByDay("Friday");

            if (list.Count != 0)
            {
                return View(list);
            }
            else
            {
                //De dag heeft geen inhoud
                return View("~/Views/Pages/Jazz");
            }
        }

        public ActionResult Saturday()
        {
            List<Jazz> list = JR.GetByDay("Saturday");

            if (list.Count != 0)
            {
                return View(list);
            }
            else
            {
                //De dag heeft geen inhoud
                return View("~/Views/Pages/Jazz");
            }
        }

        public ActionResult Sunday()
        {
            List<Jazz> list = JR.GetByDay("Sunday");

            if (list.Count != 0)
            {
                return View(list);
            }
            else
            {
                //De dag heeft geen inhoud
                return View("~/Views/Pages/Jazz");
            }
        }
    }
}