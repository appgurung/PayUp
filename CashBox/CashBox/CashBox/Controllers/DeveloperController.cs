using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace CashBox.Controllers
{
    public class DeveloperController : Controller
    {
        public  string id;
        public string secreteKey, publicKey;
        RandomGenerator generator;
        private readonly CashBoxEntities db = new CashBoxEntities();

        // GET: Developer
        public ActionResult ApiDetails()
        {

            // If session is empty redirect to login
            if (string.IsNullOrEmpty((string)GlobalData.getUerNameFromApplication))
            {
                return RedirectToAction("Index", "Home");
            }

            this.id = GlobalData.getUserIDFromApplication;

            var devKeys = db.ApiKeys.Where(x => x.MerchantID == this.id).Select(x => x).FirstOrDefault();

            ViewBag.TestSecretekey = devKeys.TestPrivateKey.Trim();

            ViewBag.TestPublickey = devKeys.TestPublicKey.Trim();

            ViewBag.LiveSecretekey = devKeys.LivePrivateKey;

            ViewBag.LivePublickey = devKeys.LivePublicKey;

            return View();
        }

        public void generateTestKeys(string email)
        {
            this.secreteKey = string.Concat("sk_test_", generator.generateSequence(12)); 

            this.publicKey = string.Concat("pk_test_", generator.generateSequence(17));

            var merchantID = db.Registrations.Where(x => x.Email == email).Select(x => x.RegistrationID).FirstOrDefault();


            var keys = new ApiKey()
            {
                TestPrivateKey = this.secreteKey,

                TestPublicKey = this.publicKey,

                MerchantID = merchantID.ToString(),

                isLiveMode = false,
            };

            db.ApiKeys.Add(keys);

            db.Entry(keys).State = System.Data.Entity.EntityState.Added;

            db.SaveChanges();
        }
    }
}