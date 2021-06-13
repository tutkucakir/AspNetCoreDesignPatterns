using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace WebApp.ChainOfResposibility.ChainOfResponsibility
{
    public class SendEmailProcessHandler : Processhandler
    {
        private readonly string _fileName;
        private readonly string _toEmail;

        public SendEmailProcessHandler(string fileName, string toEmail)
        {
            _fileName = fileName;
            _toEmail = toEmail;
        }

        public override object handle(object o)
        {
            var zipMemoryStream = o as MemoryStream;
            zipMemoryStream.Position = 0;
            var mailMessage = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("mail.tutkucakir.com.tr");
            mailMessage.From = new MailAddress("tutku@tutkucakir.com.tr");
            mailMessage.To.Add(_toEmail);
            mailMessage.Subject = "Zip Dosyanız";
            mailMessage.Body = "Zip dosyası ektedir.<hr />";
            mailMessage.Body += "<a href='#'>E-Posta Doğrulama Linki</a>";

            Attachment attachment = new Attachment(zipMemoryStream, _fileName, MediaTypeNames.Application.Zip);
            mailMessage.Attachments.Add(attachment);

            mailMessage.IsBodyHtml = true;
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential("tutku@tutkucakir.com.tr", "Tr57639100!");
            smtpClient.Send(mailMessage);
            return base.handle(null);
        }



    }
}
