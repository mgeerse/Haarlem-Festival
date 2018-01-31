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
        public ActionResult Index()
        {
            IEnumerable<Models.Subject> Subjects = SR.GetAll();

            return View("/Views/Pages/Home/index.cshtml",Subjects);
        }
    }
}