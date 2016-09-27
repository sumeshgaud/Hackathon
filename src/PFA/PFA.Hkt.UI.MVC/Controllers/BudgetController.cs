using PFA.Hkt.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessModel;

namespace PFA.Hkt.UI.MVC.Controllers
{
    public class BudgetController : Controller
    {
        //
        // GET: /Budget/
        private IBudgetService _budgetServices;
        public BudgetController(IBudgetService budgetServices)
        {
            _budgetServices = budgetServices;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllBudget()
        {
            var lstBudgt = _budgetServices.GetAllBudget().ToList();
            return Json(lstBudgt, JsonRequestBehavior.AllowGet);
        }

        public string Insert_Budget(beBudget budget)
        {
            if (budget != null)
            {
                Guid Id = _budgetServices.CreateBudget(budget);
                if(Id!=Guid.Empty)
                    return "Budget Added Successfully";  
                else
                    return "Budget Not Added! Try Again";
            }
            else
                return "Budget Not Added! Try Again";
        }


    }
}
