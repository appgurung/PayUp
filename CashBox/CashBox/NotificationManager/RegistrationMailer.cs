using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace NotificationManager
{
    public static class RegistrationMailer
    {
        public static async Task<string> Send(string fullName, string email, string subject, string path)
        {
            await Task.Run(() =>
            {
                //Send activation mail
                string body;
                //Read template file from the App_Data folder
                using (var sr = new StreamReader(path))
                {
                    body = sr.ReadToEnd();
                }
                try
                {
                    string name = fullName;

                    string sender = ConfigurationManager.AppSettings["EmailFromAddress"];

                    string emailSubject = subject;

                    string messageBody = string.Format(body, name);

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