using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessModel;
using System.Data;

namespace PFA.Hkt.UI.MVC.Controllers
{
    public class TransactionController : Controller
    {
        //
        // GET: /Transaction/

        ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public ActionResult Index()
        {
            return View(_transactionService.GetAllTransaction());
        }

        public ActionResult Create()
        {
            return View(new beTransaction());
        }

        [HttpPost]
        public ActionResult Create(beTransaction transcation)
        {
            if (transcation != null && ModelState.IsValid)
            {
                try
                {
                    _transactionService.CreateTransaction(transcation);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Unable to create transcation. Please contact your system admin for more details");
                }
            }

            else
            {
                ModelState.AddModelError("", "Please enter valid inputs");
            }

            return View();

        }

        public ActionResult Edit(Guid Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            beTransaction transcationDetailsToBeEdited = _transactionService.GetTransactionById(Id);
            if (transcationDetailsToBeEdited == null)
            {
                return HttpNotFound();
            }
            return View(transcationDetailsToBeEdited);
        }


        [HttpPost, ActionName("Edit")]
        public ActionResult EditPost([Bind(Include = "Description,CategoryId")] beTransaction transcation, Guid Id)
        {
            
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _transactionService.UpdateTransaction(Id, transcation);
                    return RedirectToAction("Index");
                }
                catch (DataException /*dbexe */)
                {
                   
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");

                }
            }
            return View(transcation);
        }



        public ActionResult Delete(Guid Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            beTransaction transcationDetailsToBeDeleted = _transactionService.GetTransactionById(Id);

            if (transcationDetailsToBeDeleted == null)
            {
                return HttpNotFound();
            }

            return View(transcationDetailsToBeDeleted);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid Id)
        {
            bool isSuccess = false;
            if (Id != null)
            {
                beTransaction transcationDetailsToBeDeleted = _transactionService.GetTransactionById(Id);
                isSuccess = _transactionService.DeleteTransaction(Id);
                if (isSuccess)
                {
                    ViewBag.Message = "Transcation Deleted Successfully";
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(Guid UserId)
        {
            if (UserId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IEnumerable<beTransaction> result = _transactionService.GetAllTransaction(UserId);

            return View(result);
        }
    }
}
