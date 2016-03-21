using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
namespace logicuniversity
{

    public class SendMail
    {
        public void sendEmail(string strFrom
                              , string strTo
                              , string strSubject
                              , string strBody)
        {

            MailMessage message;
            int flag;
            try
            {
                message = new MailMessage();
                message.Subject = strSubject;
                message.Sender = new MailAddress(strTo);
                message.From = new MailAddress(strFrom);
                message.Body = strBody;
                message.IsBodyHtml = true;

                message.To.Add(new MailAddress(strTo));

                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 25;
                client.EnableSsl = true; 
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                System.Net.NetworkCredential credential = new System.Net.NetworkCredential(strFrom, "team2rocks");
                client.Credentials = credential;
                client.Send(message); //Sending message process.


            }
            catch (Exception exception)
            {

                exception.ToString();
            }
           


        }
    }
}