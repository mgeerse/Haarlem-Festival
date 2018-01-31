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
        
        // GET: Jazz
        public ActionResult Information(string Day)
        {
            List<Jazz> list = JR.GetByDay(Day);

            if (list != null)
            {
                return View(list);
            }
            else
            {
                return View("~/Views/Pages/Jazz");
            }
        }
    }
}