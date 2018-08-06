using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CashBox.Models;
using Utilities;

namespace CashBox.Controllers
{
    public class ConfigurationController : Controller
    {
        private readonly CashBoxEntities db = new CashBoxEntities();

        // GET: Configuration
        public ActionResult Setup()
        {
            // If session is empty redirect to login
            if (string.IsNullOrEmpty((string)GlobalData.getUerNameFromApplication))
            {
                return RedirectToAction("Index", "Home");
            }

            var banks = (from x in db.Banks
                         select new
                         {
                             BankName = x.BankName,
                             SortCode = x.SortCode
                         }).ToList();


            List<Banks> bnk = new List<Banks>();

            foreach(var financialInstitution in banks)
            {
                var b = new Banks();

                b.BankName  = financialInstitution.BankName.Trim();

                b.BankCode = financialInstitution.SortCode.Trim();

                bnk.Add(b);
            }

            return View(bnk);
        }
    }
}