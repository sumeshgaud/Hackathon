using PFA.Hkt.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessModel;

namespace PFA.Hkt.UI.MVC.Controllers
{
    [AllowAnonymous]
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
                int Id = _budgetServices.CreateBudget(budget);
                if(Id!=0)
                    return "Budget Added Successfully";  
                else
                    return "Budget Not Added! Try Again";
            }
            else
                return "Budget Not Added! Try Again";
        }

        public string Delete_Budget(int Id)
        {
            if (Id != 0)
            {
              var status=  _budgetServices.DeleteBudget(Id);
                if(status)
                    return "Budget Deleted Successfully"; 
                else
                    return "Budget Not Deleted! Try Again";
            }
            return "Budget Not Deleted! Try Again";
        }


    }
}
