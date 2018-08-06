using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace CashBox.Controllers
{
    public class PayoutController : Controller
    {

        private readonly CashBoxEntities db = new CashBoxEntities();
        string id;
        // GET: PayUp
        public ActionResult Settlement()
        {

            // If session is empty redirect to login
            if (string.IsNullOrEmpty((string)GlobalData.getUerNameFromApplication))
            {
                return RedirectToAction("Index", "Home");
            }

            this.id = GlobalData.getUserIDFromApplication;


            var BusinessName = db.BusinessProfiles.Where(x => x.MerchantID == id).Select(x => x.BusinessName).FirstOrDefault();

            var BankDetails = db.SettlementDetails.Where(x => x.MerchantID.ToString() == id).Select(x => x).FirstOrDefault();

            if(BankDetails != null)
            {
                ViewBag.AccountNo = BankDetails.AccountNo.Trim();

                ViewBag.BankName = BankDetails.BankName.Trim();

                ViewBag.BusinessName = BusinessName.Trim();
            }
            else
            {
                ViewBag.AccountNo = "UnKnown";

                ViewBag.BankName = "UnKnown";

                ViewBag.BusinessName = "UnKnown";
            }
            return View();
        }

        [HttpGet]
        public JsonResult GetSettlements()
        {
            try
            {
                var settlements = (from x in db.Payouts
                                   where x.MerchantID == this.id
                                   select new
                                   {
                                       Status = x.Status,
                                       Amount = x.Amount,
                                       TotalTransactions = x.TotalTransactions,
                                       RequestCode = x.RequestCode,
                                       SettlementDate = x.SettlementDate
                                   }).ToList();

                return Json(new { data = settlements }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}