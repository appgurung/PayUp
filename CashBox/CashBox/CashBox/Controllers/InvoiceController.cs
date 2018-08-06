using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace CashBox.Controllers
{
    public class InvoiceController : Controller
    {

       public string id;

        private readonly CashBoxEntities db = new CashBoxEntities();

        // GET: Invoice
        public ActionResult PaymentRequest()
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
        public JsonResult GetPaymentRequests()
        {
            var paymentReq = (from x in db.Invoices
                              where x.MerchantID == this.id
                              select new
                              {
                                  Status = x.Status,
                                  RequestedOn = x.DateRequested,
                                  From = x.RequestedBy,
                                  Amount = x.Amount,
                                  PDF = x.isAttachmentAllowed,
                                  InvoiceID = x.InvoiceID
                              }).ToList();

            object paymentResp = new
            {

            };

            foreach(var pay in paymentReq)
            {
                var docName = db.InvoiceAttachments.Where(x => x.InvoiceID == pay.InvoiceID.ToString()).Select(x => x.DocName).FirstOrDefault();

                paymentResp = new
                {
                    Status = pay.Status,
                    RequestedOn = pay.RequestedOn,
                    From = pay.From,
                    Amount = pay.Amount,
                    PDF = docName,
                    InvoiceID = pay.InvoiceID
                };
            };

            return Json(new { data = paymentReq}, JsonRequestBehavior.AllowGet);
           
        }
    }
}