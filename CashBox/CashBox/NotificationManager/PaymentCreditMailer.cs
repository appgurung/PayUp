using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace NotificationManager
{
    public static class PaymentCreditMailer
    {
        public static async Task<string> Send(string email, string vendorName, string subject, string requestedamount, string approvedamount, string transactionno, string maskedcardno, string date, string cardtype, string Path)
        {
            await Task.Run(() =>
            {
                string body;
                //Read template file from the App_Data folder
                using (var sr = new StreamReader(Path))
                {
                    body = sr.ReadToEnd();
                }
                try
                {
                    string name = vendorName;

                    string sender = ConfigurationManager.AppSettings["EmailFromAddress"];

                    string emailSubject = subject;

                    string messageBody = string.Format(body, approvedamount, transactionno, date, cardtype, maskedcardno,requestedamount, approvedamount, name);

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