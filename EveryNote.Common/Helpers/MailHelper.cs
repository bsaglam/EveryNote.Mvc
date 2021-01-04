using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EveryNote.Common.Helpers
{
    public class MailHelper
    {
        public static bool SendMail(string body, string to, string subject, bool isHtml= true)
        {
            return SendMail(body, new List<string>() { to }, subject, isHtml);
        }
        public static bool SendMail(string body, List<string> to, string subject, bool isHtml=true)
        {
            bool result = false;
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(ConfigHelper.GetConfig<string>("username"));
                //gönderilecek liste içinde dönelim
                foreach (var item in to)
                {
                    message.To.Add(new MailAddress("item"));
                }
                message.Subject = subject;
                message.IsBodyHtml = isHtml; //to make message body as html  
                message.Body = body;
                smtp.Port = ConfigHelper.GetConfig<int>("Port");
                smtp.Host = ConfigHelper.GetConfig<string>("SmtpServer"); //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(ConfigHelper.GetConfig<string>("username"), ConfigHelper.GetConfig<string>("password"));
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                result = true;
            }
            catch (Exception)
            {

                throw;
            }


            return result;
        }
    }
}
