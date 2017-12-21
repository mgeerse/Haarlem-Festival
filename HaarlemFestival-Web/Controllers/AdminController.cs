using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaarlemFestival_Web.Models;
using HaarlemFestival_Web.Contexts;

namespace HaarlemFestival_Web.Controllers
{
    public class AdminController : Controller
    {
        FestivalContext db = new FestivalContext();

        //:Registration
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        //:Registration [POST]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(Account a)
        {
            bool status = false;
            string message = "";

            if(ModelState.IsValid)
            {
                //-Username Exist Check
                if(UsernameExists(a.Username))
                {
                    ModelState.AddModelError("UsernameExists", "Username already exists");
                }
            }
            else
            {
                message = "Invalid Request";
            }
            //-Process form data and write to database

            //-Model validation

            //-Password Hashing

            //-Store data to database



            return View(a);
        }

        //:Login


        //:Login [POST]


        //: Logout


        [NonAction]
        public bool UsernameExists(string enteredUsername)
        {
            var existingUsername = db.Accounts.Where(u => u.Username == enteredUsername).FirstOrDefault();

            return existingUsername == null ? false : true;

        }
    }
}