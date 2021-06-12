using BaseProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();

            var identityDbContext = scope.ServiceProvider.GetRequiredService<AppIdentityDbContext>();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();


            identityDbContext.Database.Migrate(); //Otomatik update-database

            // Add-Migration migrationadi komutuyla migration eklemezseniz buradaki karar yapýsý hata verecektir!
            if (!userManager.Users.Any())
            {
                userManager.CreateAsync(new AppUser() { UserName = "user1", Email = "user1@tutkucakir.com.tr", PictureUrl="/userpictures/primeuserpicture.png", Description="Bu bir profil açýklamasýdýr." }, "Password12*").Wait();
                userManager.CreateAsync(new AppUser() { UserName = "user2", Email = "user2@tutkucakir.com.tr", PictureUrl = "/userpictures/primeuserpicture.png", Description = "Bu bir profil açýklamasýdýr." }, "Password12*").Wait();
                userManager.CreateAsync(new AppUser() { UserName = "user3", Email = "user3@tutkucakir.com.tr", PictureUrl = "/userpictures/primeuserpicture.png", Description = "Bu bir profil açýklamasýdýr." }, "Password12*").Wait();
                userManager.CreateAsync(new AppUser() { UserName = "user4", Email = "user4@tutkucakir.com.tr", PictureUrl = "/userpictures/primeuserpicture.png", Description = "Bu bir profil açýklamasýdýr." }, "Password12*").Wait();
                userManager.CreateAsync(new AppUser() { UserName = "user5", Email = "user5@tutkucakir.com.tr", PictureUrl = "/userpictures/primeuserpicture.png", Description = "Bu bir profil açýklamasýdýr." }, "Password12*").Wait();
            }


            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
