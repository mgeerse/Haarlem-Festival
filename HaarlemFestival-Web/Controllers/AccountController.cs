using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaarlemFestival_Web.Models;
using HaarlemFestival_Web.Contexts;

namespace HaarlemFestival_Web.Controllers
{
    public class AccountController : Controller
    {
        FestivalContext db = new FestivalContext();

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        #region Registration
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [NonAction]
        public bool UsernameExists(string enteredUsername)
        {
            var existingUsername = db.Accounts.Where(u => u.Username == enteredUsername).FirstOrDefault();

            return existingUsername == null ? false : true;

        }

        [HttpPost]
        public ActionResult Register(Account Account)
        {
            if (ModelState.IsValid)
            {
                using (FestivalContext Db = new FestivalContext())
                {
                    Db.Accounts.Add(Account);
                    Db.SaveChanges();
                }

                ModelState.Clear();
                ViewBag.Message = Account.Name + ", your account has been successfully registered!";
            }
            return View();
        }
        #endregion

        #region login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account Account)
        {
            using (FestivalContext Db = new FestivalContext())
            {
                Account user = Db.Accounts.FirstOrDefault(u => u.Username == Account.Username && u.Password == Account.Password);

                if (user != null)
                {
                    Session["Id"] = user.Id;
                    Session["Username"] = user.Username;

                    return RedirectToAction("../Dashboard/Index");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is not correct");
                }
            }
            ViewBag.Message = "The username or password is incorrect.";

            return View("Login");
        }

        [HttpGet]
        public ActionResult LoggedIn()
        {
            if (Session["Id"] != null)
            {
                return View("LoggedIn");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        #endregion

        #region Logout
        public ActionResult Logout(Account User)
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        #endregion
    }
}