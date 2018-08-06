using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace CashBox.Controllers
{
    public class SubscriptionsController : Controller
    {
        string id;
        private readonly CashBoxEntities db = new CashBoxEntities();

        // GET: Subscriptions
        public ActionResult Plans()
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
        public JsonResult GetPlans()
        {
            var plans = (from x in db.Plans
                         where x.MerchantID == this.id
                         select new
                         {
                             PlanCode = x.PlanCode,
                             PlanName = x.PlanName,
                             Interval = x.Interval,
                             Amount = x.PlanAmount,
                             CreatedOn = x.Date,
                             PlanID = x.PlanID
                         }).ToList();

            return Json(new { data = plans }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSubscriptions()
        {
            var subscriptions = (from x in db.Subscriptions
                                 where x.MerchantID == this.id
                                 select new
                                 {
                                     CustomerName = x.CustomerName,
                                     CustomerEmail = x.CustomerEmail,
                                     PlanID = x.PlanID,
                                     Status = x.Status,
                                 }).ToList();

            object subscriptionsResp = new
            {
                
            };

            foreach( var sub in subscriptions)
            {
                var planDetails = db.Plans.Where(x => x.PlanID.ToString() == sub.PlanID).Select(x => new {
                    planInterval = x.Interval,
                    planName = x.PlanName
                }).FirstOrDefault();

                subscriptionsResp = new
                {
                    PlanName = planDetails.planName,
                    CustomerName = sub.CustomerName,
                    CustomerEmail = sub.CustomerEmail,                
                    PlanInterval = planDetails.planInterval,
                    Status  = sub.Status
                };
            }

            return Json(new { data = subscriptionsResp }, JsonRequestBehavior.AllowGet);
        }
    }
}