using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS_Project.Models;
using IS_Project.ViewModels;

namespace IS_Project.Controllers
{
    public class RecipeSubsystemController : Controller
    {
        hospitaldbContext ctx = new hospitaldbContext();
        // GET: Recepy
        public ActionResult Index()
        {
            string remedy = "";
            DateTime date = new DateTime();
            string vardas = "";
            string pavarde = "";
            int number = 0;
            if (Request.Form["Vardas"] != null)
            {
                vardas = Request.Form["Vardas"].ToString();
                pavarde = Request.Form["Pavarde"].ToString();
                number += 2;
            }
            if (Request.Form["remedy"] != null)
            {
                if (!Request.Form["remedy"].Equals(""))
                {
                    remedy = Request.Form["remedy"].ToString();
                    number += 3;
                }
            }
            if (Request.Form["date"] != null)
            {
                if (!Request.Form["date"].Equals(""))
                {
                    date = DateTime.Parse(Request.Form["date"].ToString());
                    number += 4;
                }
            }
            Receptas[] a = ctx.Receptas.ToArray();
            List<Receptas> fit = new List<Receptas>();
            for (int i = 0; i < ctx.Receptas.Count(); i++)
            {
                a[i].FkPacientas = ctx.Pacientas.Find(a[i].FkPacientasId);
                a[i].FkPacientas.PacientasNavigation = ctx.Vartotojas.Find(a[i].FkPacientas.PacientasId);
                a[i].FkVaistas = ctx.Vaistas.Find(a[i].FkVaistasId);
                switch (number)
                {
                    case 2:
                        if (a[i].FkPacientas.PacientasNavigation.Vardas.ToLower().Equals(vardas.ToLower()) &&
                            a[i].FkPacientas.PacientasNavigation.Pavarde.ToLower().Equals(pavarde.ToLower()))
                        {
                            fit.Add(a[i]);
                        }
                        break;
                    case 3:
                        if (a[i].FkVaistas.Pavadinimas.ToLower().Equals(remedy.ToLower()))
                        {
                            fit.Add(a[i]);
                        }
                        break;
                    case 4:
                        if ((a[i].Data - date).Days == 0)
                        {
                            fit.Add(a[i]);
                        }
                        break;
                    case 7:
                        if(a[i].FkVaistas.Pavadinimas.ToLower().Equals(remedy.ToLower()) && (a[i].Data - date).Days == 0)
                        {
                            fit.Add(a[i]);
                        }
                        break;
                    default:
                        fit.Add(a[i]);
                        break;
                }
            }
            return View(fit);
        }

        // GET: Recepy/Details/5
        public ActionResult SearchPatient()
        {
            return View();
        }

        // GET: Recepy/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Recepy/Create
        [HttpPost]
        public ActionResult Create(Receptas receptas)
        {
            try
            {
                ctx.Add(receptas);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Recepy/Edit/5
        public ActionResult Edit(int id)
        {
            //Receptas receptas = ctx.Receptas.Find(id);
            return View(ctx.Receptas.Find(id));
        }

        // POST: Recepy/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Receptas receptas)
        {
            try
            {
                // TODO: Add update logic here
                ctx.Receptas.Update(receptas);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CheckAlergy()
        {
            string vardas = "";
            string pavarde = "";
            string vaistas = "";
            AlergyPerson p = new AlergyPerson();
            Alergija alergija = new Alergija();
            Vaistas vaistas1 = new Vaistas();
            KomplikacijosAlergijaVaistas[] komp;
            int vaistoId = 0;
            if (Request.Form["Vardas"] != null)
            {
                vardas = Request.Form["Vardas"].ToString();
                pavarde = Request.Form["Pavarde"].ToString();
                vaistas = Request.Form["Vaistas"].ToString();
            }
            
            if (!vaistas.Equals(""))
            {
                Vaistas[] yra = ctx.Vaistas.ToArray();
                for (int i = 0; i < yra.Length; i++)
                {
                    if (yra[i].Pavadinimas.ToLower().Equals(vaistas.ToLower()))
                    {
                        vaistoId = yra[i].VaistasId;
                    }
                }
            }
            if (!vardas.Equals(""))
            {
                int id = 0;
                Vartotojas[] a = ctx.Vartotojas.ToArray();
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i].Vardas.ToLower().Equals(vardas.ToLower()) && a[i].Pavarde.ToLower().Equals(pavarde.ToLower()))
                    {
                        a[i].Pacientas = ctx.Pacientas.Find(a[i].VartotojasId);
                        id = a[i].Pacientas.PacientasId;
                    }
                    if (id != 0)
                        alergija = ctx.Alergija.Find(id);
                }
                komp = ctx.KomplikacijosAlergijaVaistas.ToArray();
                
                for (int i = 0; i < komp.Length; i++)
                {
                    if (komp[i].FkAlergijaId == alergija.AlergijaId && komp[i].FkVaistasId == vaistoId)
                        p.Tikrinimas = "Vaitai negalimi, pacientas alergiškas!";
                }
                if (p.Tikrinimas == null)
                {
                    p.Tikrinimas = "Pacientas nėra alergiškas"; 
                }
            }
            return View(p);
        }

        // GET: Recepy/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ctx.Receptas.Find(id));
        }

        // POST: Recepy/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Receptas receptas)
        {
            try
            {
                // TODO: Add delete logic here
                ctx.Receptas.Remove(ctx.Receptas.Find(id));
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
