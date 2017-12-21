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
        #region Registration
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Account Account)
        {
            if(ModelState.IsValid)
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
                Account user = Db.Accounts.Single(u => u.Username == Account.Username && u.Password == Account.Password);

                if(user != null)
                {
                    Session["Id"] = user.Id;
                    Session["Username"] = user.Username;

                    return View("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is not correct");
                }
            }

            return View("Login");
        }

        public ActionResult LoggedIn()
        {
            if(Session["Id"] != null)
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