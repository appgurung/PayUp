using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
namespace NotificationManager
{
    public class TeamInvitation
    {
        public static async Task<string> Send(string accountOwner,string RoleType, string email, string subject, string path, string link)
        {

            string DashboardPriviledge = string.Empty;

            switch(RoleType)
            {
                case "Administrator":
                    DashboardPriviledge = "The dashboard gives you access to information about the account's payments, customers, payouts, and more";
                     break;

                case "Developer":
                    DashboardPriviledge = "The dashboard gives you access to full API, settings, payouts, transactions";
                     break;

                case "Analyst":
                    DashboardPriviledge = "The dashboard gives you access to information about the transactions and settings";
                     break;
                case "Support Analyst":
                    DashboardPriviledge = "The dashboard gives you access to information about the account's payments, customers, payouts, and more";
                     break;

                case "View Only ":
                    DashboardPriviledge = "The dashboard gives you access to information about the transaction dashboard";
                     break;
            }

            await Task.Run(() =>
            {
                //Send invitation mail
                string body;
                //Read template file from the App_Data folder
                using (var sr = new StreamReader(path))
                {
                    body = sr.ReadToEnd();
                }
                try
                {

                    string sender = ConfigurationManager.AppSettings["EmailFromAddress"];

                    string emailSubject = subject;

                    string date = DateTime.Now.ToShortTimeString() + " @ " + DateTime.Now.ToShortTimeString();

                    string messageBody = string.Format(body, accountOwner, RoleType, link, DashboardPriviledge);

                    var MailHelper = new Util.MailHelper
                    {
                        Sender = sender,

                        Recipient = email,

                        RecipientCC = null,

                        Subject = emailSubject,

                        Body = messageBody
                    };

                    MailHelper.Send();
                }
                catch (Exception)
                {
                    throw;
                }
            });

            return null;
        }
    }
}