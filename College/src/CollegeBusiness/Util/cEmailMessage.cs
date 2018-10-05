using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace CollegeBusiness.Util
{
    public class cEmailMessage
    {
        public void SendEmail(cEmail data)
        {
            MailAddress maddrto = new MailAddress(data.EmailTo, data.NameTo, Encoding.GetEncoding("ISO-8859-1"));
            MailAddress maddrfrom = new MailAddress(data.EmailFrom, data.NameFrom, Encoding.GetEncoding("ISO-8859-1"));
            MailMessage mail = new MailMessage(maddrfrom, maddrto);
            if (data.EmailReply != null && data.NameReply != null)
            {
                mail.ReplyToList.Add(new MailAddress(data.EmailReply, data.NameReply, Encoding.GetEncoding("ISO-8859-1")));
            }
            mail.Body = data.Message;
            mail.Subject = data.Subject;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient(data.ServerSmtp, data.PortSmtp);
            smtp.Credentials = new NetworkCredential(data.UserSmtp, data.PasswordSmtp);
            smtp.Send(mail);
        }
    }

    public class cEmail
    {
        public string ServerSmtp { get; set; }
        public int PortSmtp { get; set; }
        public string UserSmtp { get; set; }
        public string PasswordSmtp { get; set; }
        public string NameTo { get; set; }
        public string EmailTo { get; set; }
        public string NameFrom { get; set; }
        public string EmailFrom { get; set; }
        public string NameReply { get; set; }
        public string EmailReply { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public string UrlBase { get; set; }
        public string Url { get; set; }
        public string ForgotPassword { get; set; }

        public string ContactMessage { get; set; }
    }

}
