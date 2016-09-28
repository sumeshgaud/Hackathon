using PFA.Hkt.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Authentication;
using BusinessModel;
using System.Web.Security;

namespace PFA.Hkt.UI.MVC.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Login()
        {
            ViewBag.success = "true";
            return View();
        }
       
        [HttpPost]
        public ActionResult Login(string password, string userName)
        {
            if (_userService.IsValid(userName, password))
            {
                FormsAuthentication.SetAuthCookie(userName, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.success = "false";
                ViewBag.message = "Username and password incorrect. Try later.";
                return View();
            }

        }
       
        public ActionResult Register()
        {
            return View();
        }

         [HttpPost]
        public ActionResult SubmitRegistration(beUser registrationViewModel)
        {
            registrationViewModel.CreatedBy = User.Identity.Name;
            registrationViewModel.CreatedOn = DateTime.Now;
            registrationViewModel.ModifiedOn = DateTime.Now;
            registrationViewModel.CreatedBy = User.Identity.Name;
            int userId = _userService.CreateUser(registrationViewModel);
            if (userId != null)
                return Json(new { Success= true }, JsonRequestBehavior.AllowGet);
            else
                return View("Register");
        }

       
        public JsonResult GetAllCurrencyList()
        {
            return Json(_userService.GetAllCurrency(), JsonRequestBehavior.AllowGet);
        }
    }
}
