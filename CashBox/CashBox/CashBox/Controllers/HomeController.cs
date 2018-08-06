using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CashBox.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PaymentGateway()
        {
            return View();
        }

        public ActionResult Enterprise()
        {
            return View();
        }

        public ActionResult Developers()
        {
            return View();
        }

    }
}