using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessModel;

namespace PFA.Hkt.UI.MVC.Controllers
{
    public class SettingController : Controller
    {
        private readonly ICommonService _commonService;

        public SettingController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(beCategory beCategory)
        {
            if (beCategory != null && ModelState.IsValid)
            {
                try
                {
                    _commonService.CreateCategory(beCategory);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Unable to create category. Please contact your system admin for more details");
                }
            }

            else
            {
                ModelState.AddModelError("", "Please enter a Unique number");
            }

            return View();

        }

        public ActionResult GetAllCategory()
        {
            var userId = Guid.Parse("d0f2801c-537a-49a1-a053-addc99bb43da");
            var categories = _commonService.GetAllCategory(userId);
            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(Guid UserId, Guid ParentCategoryId)
        {
            bool successStatus = false;

            if (UserId != null)
            {
                successStatus = _commonService.DeleteCategory(UserId);
                if (successStatus)
                {
                    ViewBag.Message = "Category Deleted Successfully";
                }
            }

            return View();
        }

    }
}
