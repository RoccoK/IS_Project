using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IS_Project.Models;
using Microsoft.EntityFrameworkCore;
using MailKit;
using MimeKit;
using MailKit.Net.Smtp;

namespace IS_Project.Controllers
{
    public static class EmailController
    {

        static hospitaldbContext ctx = new hospitaldbContext();

        public static void SendMailRegister(Registracija registracija)
        {
            var vart = ctx.Vartotojas.Find(registracija.FkPacientasId);
            var doc = ctx.Daktaras.Where(d => d.DaktarasId == registracija.FkDaktarasId).Include(d => d.DaktarasNavigation).FirstOrDefault();


            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Ligoninės Sistema", "lisqrnd@gmx.com"));
            message.To.Add(new MailboxAddress("Pacientas", vart.Elpastas));
            message.Subject = "Registracijos patvirtinimas";

            message.Body = new TextPart("plain")
            {
                Text =  "Jūs užsiregistravote ligoninės sitemoje\n" +
                        "Registracijos duomenys:\n" +
                        "Patekimo data: " + registracija.PateikimoData.ToString() +
                        "\nVisito data: " + registracija.VisitoData.ToString() +
                        "\nGydytojas: " + doc.DaktarasNavigation.Vardas + " " + doc.DaktarasNavigation.Pavarde + " " + ((Specializacijos)doc.Specializacija).ToString("g")
            };

            using (var client = new SmtpClient())
            {
                client.Connect("mail.gmx.com", 587);
                


                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("lisqrnd@gmx.com", "BigBang0258");

                client.Send(message);
                client.Disconnect(true);
            }
        }

    }
}
