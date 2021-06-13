using BaseProject.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebApp.Observer.Observer
{
    public class UserObserverSendMail : IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public UserObserverSendMail(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreateUser(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverSendMail>>();
            var mailMessage = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("mail.tutkucakir.com.tr");
            mailMessage.From = new MailAddress("tutku@tutkucakir.com.tr");
            mailMessage.To.Add(appUser.Email);
            mailMessage.Subject = "Sitemize hoş geldiniz...";
            mailMessage.Body = "<h2>Sitemize Hoşgeldin!</h2><h3>E-Posta adresinizi doğrulamak için lütfen aşağıdaki linke tıklayınız. </h3><hr />";
            mailMessage.Body += "<a href='#'>E-Posta Doğrulama Linki</a>";
            mailMessage.IsBodyHtml = true;
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential("tutku@tutkucakir.com.tr", "Tr57639100!");
            smtpClient.Send(mailMessage);
            logger.LogInformation($"Email was send to user: {appUser.UserName}");
        }
    }
}
