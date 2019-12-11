using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS_Project.Models;
using IS_Project.ViewModels;

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
            try
            {
                if (ModelState.IsValid)
                {
                    
                }

            }
            catch
            {
                return View(usr);
            }
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
            Pacientas p = ctx.Pacientas.Find(id);
            usr.GimimoData = p.GimimoData.Date;
            return View(usr);
        }
        [HttpPost]
        public ActionResult DeleteUser(int id, User usr)
        {
            try
            {
                ctx.Remove(ctx.Pacientas.Find(id));
                ctx.Remove(ctx.Adresas.Find(id));
                ctx.Remove(ctx.Vartotojas.Find(id));
                ctx.Remove(ctx.Daktaras.Find(id));
                ctx.SaveChanges();
                return RedirectToAction("../");
            }
            catch
            {
                ModelState.AddModelError("id", "Toks vartotojas neegizstuoja");

                return View();
            }
        }
        public ActionResult SendReminder()
        {
            return View();
        }
        public ActionResult UserLookup()
        {
            return View();
        }
        public ActionResult ViewUserData()
        {
            int id = 5;
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
            Pacientas p = ctx.Pacientas.Find(id);
            usr.GimimoData = p.GimimoData.Date;
            return View(usr);
        }
        public ActionResult EditUserData(int id)
        {
            return View();
        }
        public ActionResult EditUser(int id)
        {
            //prefill edit form with data
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
            Pacientas p = ctx.Pacientas.Find(id);
            usr.GimimoData = p.GimimoData.Date;
            return View(usr);
        }
        // skidaddle, skidoodle, your code is now a noodle
        [HttpPost]
        public ActionResult EditUser(int id, User usr)
        {
            try
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

                Pacientas p = ctx.Pacientas.Find(id);
                p.GimimoData = usr.GimimoData;
                ctx.Update(p);
                ctx.SaveChanges();
                return RedirectToAction("/ViewUserData");
            }
            catch
            {
                ModelState.AddModelError("id", "Toks vartotojas neegizstuoja");

                return View();
            }
        }
    }
}