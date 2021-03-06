﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessModel;
using System.Net;

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

        public ActionResult Create(beCategory category)
        {
            if (category != null && ModelState.IsValid)
            {
                try
                {
                    _commonService.CreateCategory(category);
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
            var userId = int.Parse("9673fa47-354a-4e3e-bfc0-47fc3b8f0677");

            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var categories = _commonService.GetAllCategory(userId);
            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int UserId, int Id)
        {
            bool successStatus = false;

            if (Id != null)
            {
                successStatus = _commonService.DeleteCategory(Id);
                if (successStatus)
                {
                    ViewBag.Message = "Category Deleted Successfully";
                }
            }

            return View();
        }

    }
}
