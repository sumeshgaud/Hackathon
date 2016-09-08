using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessModel;

namespace PFA.Hkt.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private readonly IAccountService _accountServices;
        public HomeController(IAccountService accountServices)
        {
            _accountServices = accountServices;
        }

        public ActionResult Index()
        {
            var objModel = _accountServices.GetAllAccounts();
            string strName = string.Empty;
            foreach (var item in objModel)
            {
                strName = item.Description;
            }
            ViewBag.FirstName = strName;
            return View();
        }

    }
}
