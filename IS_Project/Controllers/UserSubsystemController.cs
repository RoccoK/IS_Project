using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS_Project.Models;

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
        public ActionResult AddUser()
        {
            return View();
        }
        public ActionResult DeleteUser(int id)
        {
            Vartotojas v = ctx.Vartotojas.Find(id);
            ViewModels.User usr = new ViewModels.User();
            usr.id = v.VartotojasId;
            usr.Vardas = v.Vardas;
            usr.Pavarde = v.Pavarde;
            usr.Pastas = v.Elpastas;
            usr.Telefonas = v.TelNr;
            Adresas adr = ctx.Adresas.Find(id);
            usr.Miestas = adr.Miestas;
            usr.Gatve = adr.Gatve;
            usr.Namas = adr.NamoNr.ToString();
            usr.PastoKodas = adr.PastoKodas.ToString();
            Pacientas p = ctx.Pacientas.Find(id);
            usr.GimimoData = p.GimimoData.Date;
            return View(usr);
        }
        [HttpPost]
        public ActionResult DeleteUser(int id, ViewModels.User usr)
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
            int id = 4;
            Vartotojas v = ctx.Vartotojas.Find(id);
            ViewModels.User usr = new ViewModels.User();
            usr.id = v.VartotojasId;
            usr.Vardas = v.Vardas;
            usr.Pavarde = v.Pavarde;
            usr.Pastas = v.Elpastas;
            usr.Telefonas = v.TelNr;
            Adresas adr = ctx.Adresas.Find(id);
            usr.Miestas = adr.Miestas;
            usr.Gatve = adr.Gatve;
            usr.Namas = adr.NamoNr.ToString();
            usr.PastoKodas = adr.PastoKodas.ToString();
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
            ViewModels.User usr = new ViewModels.User();
            usr.id = v.VartotojasId;
            usr.Vardas = v.Vardas;
            usr.Pavarde = v.Pavarde;
            usr.Pastas = v.Elpastas;
            usr.Telefonas = v.TelNr;
            Adresas adr = ctx.Adresas.Find(id);
            usr.Miestas = adr.Miestas;
            usr.Gatve = adr.Gatve;
            usr.Namas = adr.NamoNr.ToString();
            usr.PastoKodas = adr.PastoKodas.ToString();
            Pacientas p = ctx.Pacientas.Find(id);
            usr.GimimoData = p.GimimoData.Date;
            return View(usr);
        }
        // skidaddle, skidoodle, your code is now a noodle
        [HttpPost]
        public ActionResult EditUser(int id, ViewModels.User usr)
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
                adr.NamoNr = Int32.Parse(usr.Namas);
                adr.PastoKodas = Int32.Parse(usr.PastoKodas);
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