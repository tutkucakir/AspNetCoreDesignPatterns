﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Template.UserCards
{
    public class PrimeUserCardTemplate : UserCardTemplate
    {
        protected override string SetFooter()
        {
            var sb = new StringBuilder();

            sb.Append("<a href='' class='card-link'>Mesaj Gönder</a>");
            sb.Append("<a href='' class='card-link'>Detaylı Profil</a>");
            return sb.ToString();
        }

        protected override string SetPicture()
        {
            return $"<img class='card-img-top' src='{_appUser.PictureUrl}'>";
        }
    }
}
