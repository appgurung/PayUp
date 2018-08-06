using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilities;
namespace CashBox.Controllers
{
    public class PaymentPageController : Controller
    {
        string id;

        private readonly CashBoxEntities db = new CashBoxEntities();

        // GET: PaymentPage
        public ActionResult Page()
        {
            // If session is empty redirect to login
            if (string.IsNullOrEmpty((string)GlobalData.getUerNameFromApplication))
            {
                return RedirectToAction("Index", "Home");
            }

            this.id = GlobalData.getUserIDFromApplication;

            return View();
        }


        [HttpGet]
        public JsonResult GetPaymentPages()
        {
            var pages = (from x in db.PaymentPages
                         where x.MerchantID == this.id
                         select new
                         {
                             PageName = x.PageName,
                             Description = x.PageDescription,
                             Type = x.Type,
                             Amount = x.Amount,
                             DateCreated = x.Date,
                             Link = "<a href =http://localhost:53656/PaymentPage/RenderPage/" + x.Link + " target='_blank'>View Page</a>",
                         }).ToList();

            return Json(new { data = pages }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult VerifyCustomlink(string link)
        {
            var checkLink = db.PaymentPages.Where(x => x.CustomLink == link && x.MerchantID == this.id).Count();

            if(checkLink > 0)
            {
                return Json("Taken", JsonRequestBehavior.AllowGet);
            }
            return Json("Available", JsonRequestBehavior.AllowGet);
        }
    }
}