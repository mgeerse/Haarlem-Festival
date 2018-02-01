﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaarlemFestival_Web.Contexts;

namespace HaarlemFestival_Web.Controllers
{
    public class HomeController : Controller
    {
        private Repositories.SubjectRepository SR = new Repositories.SubjectRepository();

        public ActionResult Index()
        { 
            return View("/Views/Pages/Home/index.cshtml");
        }
    }
}