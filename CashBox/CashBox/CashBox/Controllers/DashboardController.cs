using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CashBox.Constants;
using Utilities;

namespace CashBox.Controllers
{
    public class MerchantController : Controller
    {
        string id;
        double balanceSummation;
        private readonly CashBoxEntities db = new CashBoxEntities();
        // GET: Dashboard
        public ActionResult Dashboard()
        {
            // If session is empty redirect to login
            if (string.IsNullOrEmpty((string)GlobalData.getUerNameFromApplication))
            {
                return RedirectToAction("Index", "Home");
            }
            GlobalData global = new GlobalData();

            this.id = GlobalData.getUserIDFromApplication;

            var FullName = db.Registrations.Where(x => x.RegistrationID.ToString() == this.id).Select(x => x.BusinessName).FirstOrDefault().ToString();

            var modeType = db.ApiKeys.Where(x => x.MerchantID == this.id && x.isLiveMode == true).Count();

            //If in live mode, get live transactions
            if(modeType > 0)
            {
                var Balance = db.LiveTransactions.Where(x => x.MerchantID == this.id && x.ResponseCode == "0").Select(x => x).ToList();

                this.balanceSummation = Balance.Sum(x => Convert.ToDouble(x.Amount));
            }
            else
            {
                //else get test transactions
                var Balance = db.TestTransactions.Where(x => x.MerchantID == this.id && x.ResponseCode == "0").Select(x => x).ToList();

                this.balanceSummation = Balance.Sum(x => Convert.ToDouble(x.Amount));
            }    

            global.setCurrentBalanceFromApplication(this.balanceSummation.ToString());

            global.setFullNameFromApplication(FullName);
            
            return View();
        }         
        
    }
}