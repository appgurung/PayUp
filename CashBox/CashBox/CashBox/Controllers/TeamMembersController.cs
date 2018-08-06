using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CashBox.Models;
using Utilities;

namespace CashBox.Controllers
{
    public class TeamMembersController : Controller
    {
        string id;

        private readonly CashBoxEntities db = new CashBoxEntities();

        // GET: TeamMembers
        public ActionResult Users()
        {

            // If session is empty redirect to login
            if (string.IsNullOrEmpty((string)GlobalData.getUerNameFromApplication))
            {
                return RedirectToAction("Index", "Home");
            }

            this.id = GlobalData.getUserIDFromApplication;

            var TeamRole = (from x in db.Roles
                            select new
                            {
                                RoleID = x.RoleID,
                                RoleType = x.RoleName,
                                RoleDescription = x.RoleDescription
                            }).ToList();
            List<Team> team = new List<Team>();
            foreach (var item in TeamRole)
            {
                var t = new Team();

                t.RoleID = item.RoleID.ToString().Trim();

                t.RoleType = item.RoleType.Trim();

                t.RoleDescription = item.RoleDescription.Trim();

                team.Add(t);
            }

            return View(team);
        }

        [HttpGet]
        public JsonResult GetTeamMembers()
        {
            var members = (from x in db.TeamMembers
                           where x.MerchantID == this.id
                           select new
                           {
                               User = x.UserName,
                               Role = x.Role,
                               LastLogin = x.LastLogin,
                               MemberID = x.TeamID,
                           }).ToList();

            return Json(new { data = members }, JsonRequestBehavior.AllowGet);
        }
    }
}