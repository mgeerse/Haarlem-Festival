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
        JazzRepository jazzRepository = new JazzRepository();
        
        public ActionResult Day(string Day)
        {
            List<Jazz> Jazzs = jazzRepository.GetByDay(Day);

            return View(Jazzs);
        }
    }
}