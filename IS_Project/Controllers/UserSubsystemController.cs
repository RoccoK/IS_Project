﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS_Project.Models;
using IS_Project.ViewModels;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace IS_Project.Controllers
{
    public class UserSubsystemController : Controller
    {
        hospitaldbContext ctx = new hospitaldbContext();

        // GET: UserSubsystem
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SendEmail()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendEmail(Email model)
        {
            if (ModelState.IsValid)
            {
                SmtpClient client = new SmtpClient("smtp.mail.com");
                client.Credentials = new NetworkCredential("roccofakeaccount@mail.com", "rocco123");
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("roccofakeaccount@mail.com");
                mailMessage.To.Add(model.ToEmail);
                mailMessage.Subject = "Priminimas";
                mailMessage.Body = model.Message;
                client.Send(mailMessage);
                return RedirectToAction("../");

            }
            return View(model);
        }
        public ActionResult PreAddUser()
        {
            return View();
        }
        public ActionResult AddDoctorUser()
        {
            User userView = new User();
            return View(userView);
        }
        [HttpPost]
        public ActionResult AddDoctorUser(User usr)
        {

            Vartotojas v = new Vartotojas();
            v.Vardas = usr.Vardas;
            v.Pavarde = usr.Pavarde;
            v.Elpastas = usr.Pastas;
            v.TelNr = usr.Telefonas;

            Adresas adr = new Adresas();
            adr.Miestas = usr.Miestas;
            adr.Gatve = usr.Gatve;
            adr.NamoNr = usr.Namas;
            adr.PastoKodas = usr.PastoKodas;
            v.Adresas = adr;

            Daktaras dr = new Daktaras();
            dr.Specializacija = (int)Specializacijos.Chirurgas;
            dr.PradetaDirbti = DateTime.Now;
            dr.Busena = (int)DarboBusenos.Dirbantis;
            dr.DaktarasId = ctx.Vartotojas.Last().VartotojasId + 1;
            v.Daktaras = dr;

            ctx.Add(v);
            ctx.SaveChanges();
            return RedirectToAction("../");
        }
        public ActionResult AddPatientUser()
        {
            User userView = new User();
            return View(userView);
        }
        [HttpPost]
        public ActionResult AddPatientUser(User usr)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    Vartotojas v = new Vartotojas();
                    v.Vardas = usr.Vardas;
                    v.Pavarde = usr.Pavarde;
                    v.Elpastas = usr.Pastas;
                    v.TelNr = usr.Telefonas;

                    Adresas adr = new Adresas();
                    adr.Miestas = usr.Miestas;
                    adr.Gatve = usr.Gatve;
                    adr.NamoNr = usr.Namas;
                    adr.PastoKodas = usr.PastoKodas;
                    v.Adresas = adr;

                    Pacientas p = new Pacientas();
                    p.GimimoData = usr.GimimoData;
                    p.GimimoMiestas = usr.GimimoMiestas;
                    p.GimLigoninėsPav = usr.GimimoLigoninesPav;
                    p.DraudimoNr = usr.DraudimoNr;
                    p.GimimoLaikas = new TimeSpan(12, 0, 0);
                    v.Pacientas = p;

                    ctx.Add(v);
                    ctx.SaveChanges();
                    //markeRepository.addMarke(collection);
                }

                return RedirectToAction("../");
            }
            catch
            {
                return View(usr);
            }
        }
        public ActionResult DeleteUser(int id)
        {
            Vartotojas v = ctx.Vartotojas.Find(id);
            User usr = new User();
            usr.id = v.VartotojasId;
            usr.Vardas = v.Vardas;
            usr.Pavarde = v.Pavarde;
            usr.Pastas = v.Elpastas;
            usr.Telefonas = v.TelNr;
            Adresas adr = ctx.Adresas.Find(id);
            usr.Miestas = adr.Miestas;
            usr.Gatve = adr.Gatve;
            usr.Namas = adr.NamoNr;
            usr.PastoKodas = adr.PastoKodas;
            return View(usr);
        }
        [HttpPost]
        public ActionResult DeleteUser(int id, User usr)
        {
            ctx.Remove(ctx.Pacientas.Find(id));
            ctx.Remove(ctx.Adresas.Find(id));
            if (!(ctx.Vartotojas.Find(id) == null))
            {
                ctx.Remove(ctx.Vartotojas.Find(id));

            }
            if (!(ctx.Daktaras.Find(id) == null))
            {
                ctx.Remove(ctx.Daktaras.Find(id));

            }
            if (!(ctx.Receptas.Find(id) == null))
            {
                ctx.Remove(ctx.Receptas.Find(id));
            }

            ctx.SaveChanges();
            return RedirectToAction("../");
        }

        public ActionResult UserLookup(string vp)
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLookup(VardasPavarde vp)
        {
            return View();
        }
        public ActionResult ViewUserData()
        {
            int id = 10;
            if (Request.Form["Vardas"] != null)
            {
                var vart = ctx.Vartotojas
                       .Where(x => x.Vardas == Request.Form["Vardas"].ToString() 
                       && x.Pavarde == Request.Form["Pavarde"].ToString())
                       .FirstOrDefault();
                id = vart.VartotojasId;
            }
            Vartotojas v = ctx.Vartotojas.Find(id);
            User usr = new User();
            usr.id = v.VartotojasId;
            usr.Vardas = v.Vardas;
            usr.Pavarde = v.Pavarde;
            usr.Pastas = v.Elpastas;
            usr.Telefonas = v.TelNr;
            Adresas adr = ctx.Adresas.Find(id);
            usr.Miestas = adr.Miestas;
            usr.Gatve = adr.Gatve;
            usr.Namas = adr.NamoNr;
            usr.PastoKodas = adr.PastoKodas;
            return View(usr);
        }
        public ActionResult EditUserData(int id)
        {
            return View();
        }
        public ActionResult EditUser(int id)
        {
            Vartotojas v = ctx.Vartotojas.Find(id);
            User usr = new User();
            usr.id = v.VartotojasId;
            usr.Vardas = v.Vardas;
            usr.Pavarde = v.Pavarde;
            usr.Pastas = v.Elpastas;
            usr.Telefonas = v.TelNr;
            Adresas adr = ctx.Adresas.Find(id);
            usr.Miestas = adr.Miestas;
            usr.Gatve = adr.Gatve;
            usr.Namas = adr.NamoNr;
            usr.PastoKodas = adr.PastoKodas;
            return View(usr);
        }


        [HttpPost]
        public ActionResult EditUser(int id, User usr)
        {
            Vartotojas v = ctx.Vartotojas.Find(id);
            v.VartotojasId = usr.id;
            v.Vardas = usr.Vardas;
            v.Pavarde = usr.Pavarde;
            v.Elpastas = usr.Pastas;
            v.TelNr = usr.Telefonas;
            ctx.Update(v);

            Adresas adr = ctx.Adresas.Find(id);
            adr.Miestas = usr.Miestas;
            adr.Gatve = usr.Gatve;
            adr.NamoNr = usr.Namas;
            adr.PastoKodas = usr.PastoKodas;
            ctx.Update(adr);

            ctx.SaveChanges();
            return RedirectToAction("/ViewUserData");
        }
    }
}