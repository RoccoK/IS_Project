using System;
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
                client.Credentials = new NetworkCredential("ISP.Mailer@mail.com", "rocco123");
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("ISP.Mailer@mail.com");
                mailMessage.To.Add(model.ToEmail);
                mailMessage.Subject = "Priminimas";
                mailMessage.Body = model.Message;
                client.Send(mailMessage);
                return RedirectToAction("../Home/Index");

            }
            return View(model);
        }
        public ActionResult PreAddUser()
        {
            return View();
        }
        public ActionResult AddDoctorUser()
        {
            ViewModels.User userView = new ViewModels.User();
            return View(userView);
        }
        [HttpPost]
        public ActionResult AddDoctorUser(ViewModels.User usr)
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
            return RedirectToAction("../Home/Index");
        }
        public ActionResult AddPatientUser()
        {
            ViewModels.User userView = new ViewModels.User();
            return View(userView);
        }
        [HttpPost]
        public ActionResult AddPatientUser(ViewModels.User usr)
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

                return RedirectToAction("../Home/Index");
            }
            catch
            {
                return View(usr);
            }
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
            usr.Namas = adr.NamoNr;
            usr.PastoKodas = adr.PastoKodas;
            return View(usr);
        }
        [HttpPost]
        public ActionResult DeleteUser(int id, ViewModels.User usr)
        {
            //if(Convert.ToInt32(Session["role"]) == 1 &&
            //    ctx.Administratorius.Find(id) != null)
            //{
            //    Session["state"] = 0;
            //}
            Session["state"] = 0;
            ctx.Remove(ctx.Adresas.Find(id));
            ctx.Remove(ctx.Vartotojas.Find(id));
            if(Convert.ToInt32(Session["role"]) == 3)
            {
                ctx.Remove(ctx.Pacientas.Find(id));
            }
            //if (!(ctx.Vartotojas.Find(id) == null))
            //{
            //    ctx.Remove(ctx.Vartotojas.Find(id));

            //}
            //if (!(ctx.Daktaras.Find(id) == null))
            //{
            //    ctx.Remove(ctx.Daktaras.Find(id));

            //}
            //if (!(ctx.Receptas.Find(id) == null))
            //{
            //    ctx.Remove(ctx.Receptas.Find(id));
            //}

            ctx.SaveChanges();
            return RedirectToAction("../Home/Index");
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
            int id;
            if(Convert.ToInt32(Session["loadmain"]) == 1)
            {
                id = Convert.ToInt32(Session["id"]);
            }
            else
            {
                id = Convert.ToInt32(Session["id2"]);
                Session["loadmain"] = 1;
            }
            if (Request.Form["Vardas"] != null && Request.Form["Pavarde"] != null)
            {
                var vart = ctx.Vartotojas
                       .Where(x => x.Vardas == Request.Form["Vardas"].ToString() 
                       && x.Pavarde == Request.Form["Pavarde"].ToString())
                       .FirstOrDefault();
                if(vart == null)
                {
                    return (RedirectToAction("UserLookup", "UserSubsystem"));
                }
                id = vart.VartotojasId;
            }
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
            ViewModels.User usr = new ViewModels.User();
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
        public ActionResult EditUser(int id, ViewModels.User usr)
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
            Session["id2"] = id;
            Session["loadmain"] = 0;
            return RedirectToAction("/ViewUserData");
        }
    }
}