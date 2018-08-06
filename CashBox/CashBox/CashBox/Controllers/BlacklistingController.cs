using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace CashBox.Controllers
{
    public class BlacklistingController : Controller
    {

        public string id;

        private readonly CashBoxEntities db = new CashBoxEntities();

        // GET: Blacklisting
        public ActionResult Card()
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
        public JsonResult GetBlacklistedCards()
        {
            var cards = (from x in db.CardBlacklists
                         where x.MerchantID == this.id
                         select new
                         {
                             CardIssuerer = x.CardIssuerer,
                             FirstSix = x.FirstSixDigits,
                             LastFour = x.LastFourDigits,
                             CardType = x.CardType,
                             Date = x.Date,
                             CardID = x.CardBlacklistID
                         }).ToList();

            return Json(new { data = cards }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Ip()
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
        public JsonResult GetBlacklsitedIps()
        {
            var Ips = (from x in db.IpBlacklistings
                       where x.MerchantID == this.id
                       select new
                       {
                           Reasson = x.Reason,
                           Country = x.Country,
                           Ip = x.IpAddress,
                           Date = x.Date,
                           IpID = x.IpBlacklistingID,
                       }).ToList();

            return Json(new { data = Ips }, JsonRequestBehavior.AllowGet);
        }
    }
}