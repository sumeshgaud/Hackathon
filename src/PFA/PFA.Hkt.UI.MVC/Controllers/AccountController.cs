using PFA.Hkt.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessModel;

namespace PFA.Hkt.UI.MVC.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Login()
        {
            ViewBag.success = "true";
            return View();
        }

        [HttpPost]
        public ActionResult Login(string password, string userName)
        {
            ViewBag.success = "false";
            ViewBag.message = "Username and password incorrect. Try later.";
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult SubmitRegistration(RegistrationViewModel registrationViewModel)
        {
            return View("Register");
        }

    }
}
