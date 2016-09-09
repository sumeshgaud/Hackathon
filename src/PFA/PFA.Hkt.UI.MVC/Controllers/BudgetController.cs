using PFA.Hkt.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PFA.Hkt.UI.MVC.Controllers
{
    public class BudgetController : Controller
    {
        //
        // GET: /Budget/
         
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllBudget()
        {

            List<BudgetViewModel> budgetViewModelList = new List<BudgetViewModel>();
            budgetViewModelList.Add(new BudgetViewModel() { CategoryName = "Shoping", Amount = 30, Type = "Expense", RecievedAmmount = 18, Month = 8, Year = 2016 });
            budgetViewModelList.Add(new BudgetViewModel() { CategoryName = "Clothing", Amount = 40, Type = "Expense", RecievedAmmount = 18, Month = 8, Year = 2016 });
            budgetViewModelList.Add(new BudgetViewModel() { CategoryName = "Petrol", Amount = 50, Type = "Income", RecievedAmmount = 18, Month = 8, Year = 2016 });
            budgetViewModelList.Add(new BudgetViewModel() { CategoryName = "Grocery", Amount = 30, Type = "Income", RecievedAmmount = 18, Month = 8, Year = 2016 });
            budgetViewModelList.Add(new BudgetViewModel() { CategoryName = "Fun", Amount = 60, Type = "Income", RecievedAmmount = 18, Month = 8, Year = 2016 });
            return Json(budgetViewModelList, JsonRequestBehavior.AllowGet);
        }


    }
}
