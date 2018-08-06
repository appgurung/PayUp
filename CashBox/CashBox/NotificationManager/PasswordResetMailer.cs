using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
namespace NotificationManager
{
    public class PasswordResetMailer
    {
        public static async Task<string> Send(string Name, string Email, string ResetLink, string Subject, string Path)
        {
            await Task.Run(() =>
            {
                //Send activation mail
                string body;
                //Read template file from the App_Data folder
                using (var sr = new StreamReader(Path))
                {
                    body = sr.ReadToEnd();
                }
                try
                {
                    string name = Name;

                    string sender = ConfigurationManager.AppSettings["EmailFromAddress"];

                    string emailSubject = Subject;

                    string messageBody = string.Format(body, name, ResetLink);

                    var MailHelper = new Util.MailHelper
                    {
                        Sender = sender,

                        Recipient = Email,

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