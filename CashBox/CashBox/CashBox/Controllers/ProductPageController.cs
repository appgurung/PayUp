using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace CashBox.Controllers
{
    public class ProductPageController : Controller
    {
        string id;
        private readonly CashBoxEntities db = new CashBoxEntities();

        // GET: Product
        public ActionResult Product()
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
        public JsonResult GetProductPages()
        {
            var pages = (from x in db.ProductPages
                         where x.MerchantID == this.id
                         select new
                         {
                             PageName = x.PageName,
                             Description = x.ProductDescription,
                             Type = x.Type,
                             PageID = x.ProductPageID,
                             Link = "<a href =http://localhost:53656/PaymentPage/RenderPage/" + x.Link + " target='_blank'>View Page</a>",
                             Date = x.Date,
                         }).ToList();

            object pageResp = new {

            };

            foreach(var page in pages)
            {
               var amt = db.ProductPrices.Where(x => x.ProductPageID.ToString() == page.PageID.ToString()).Select(x => x.Price).FirstOrDefault();

                pageResp = new
                {
                    PageName = page.PageName,
                    Description = page.Description,
                    Type = page.Type,
                    DateCreated = page.Date,
                    Link = page.Link,
                    Amount = amt
                };
            }
            return Json(new { data = pageResp }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult VerifyCustomlink(string link)
        {
            var checkLink = db.ProductPages.Where(x => x.CustomLink == link && x.MerchantID == this.id).Count();

            if (checkLink > 0)
            {
                return Json("Taken", JsonRequestBehavior.AllowGet);
            }
            return Json("Available", JsonRequestBehavior.AllowGet);
        }
    }
}