using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS_Project.Models;
using IS_Project.ViewModels;

namespace IS_Project.Controllers
{
    public class RegistrationSubsystemController : Controller
    {
        hospitaldbContext db = new hospitaldbContext();       
        // GET: RegistrationSubsystem
        public ActionResult Index()
        {
            var registracija = db.Registracija.ToList();
            List<Registracija> select = new List<Registracija>();
            foreach(var item in registracija)
            {
                if(item.FkPacientasId == Convert.ToInt32(Session["id"]))
                {
                    select.Add(item);
                }
            }
            return View();
        }

        public ActionResult timetable()
        {
            //List<UzimtumoTvarkarastis> tvarkarastis = new List<UzimtumoTvarkarastis>();
            var tvark = db.UzimtumoTvarkarastis.ToList();
            return View(tvark);
        }

        // GET: RegistrationSubsystem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistrationSubsystem/Create
        public ActionResult Create()
        {
            RegistrationView registratoinview = new RegistrationView();
            PopulateSelections(registratoinview);
            return View(registratoinview);
        }

        // POST: RegistrationSubsystem/Create
        [HttpPost]
        public ActionResult Create(RegistrationView registrationView)
        {
            try
            {
                Registracija registracija = new Registracija();
                //var tvarkarastis = db.UzimtumoTvarkarastis.Where(x => x.UzimtumoTvarkarastisId == Convert.ToInt32(registrationView.VisitoData) &&
                //                                           x.FkDaktarasId == registrationView.FkDaktarasId).FirstOrDefault();
                //if (tvarkarastis != null)
                //{
                //    if (tvarkarastis.TrukmeMin >= 540)
                //    {
                //        ModelState.AddModelError("", "Laikas negalimas");
                //    }
                //    else
                //    {
                //        tvarkarastis.TrukmeMin += 30;
                //    }
                //}
                //else
                //{
                //    UzimtumoTvarkarastis uzimtumas = new UzimtumoTvarkarastis();
                //    uzimtumas.FkDaktarasId = registrationView.FkDaktarasId;
                //    uzimtumas.TrukmeMin += 30;
                //    uzimtumas.UzimtumoTvarkarastisId = Convert.ToInt32(registrationView.VisitoData);
                //}

                var checkboxChecked = Request.Form["check"];
                if (checkboxChecked == null)
                {
                    checkboxChecked = "0";
                }
                registracija.VisitoData = registrationView.VisitoData;
                registracija.FkDaktarasId = registrationView.FkDaktarasId;
                registracija.FkPacientasId = Convert.ToInt32(Session["id"]);
                registracija.KviestaGreitoji = Convert.ToSByte(checkboxChecked);
                registracija.Busena = 1;
                registracija.PateikimoData = DateTime.Now;
                db.Add(registracija);
                db.SaveChanges();
                return RedirectToAction("Index");             
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistrationSubsystem/Edit/5
        public ActionResult Edit(int id)
        {
            RegistrationView registrationView = new RegistrationView();
            PopulateSelections(registrationView);          
            Registracija registration = db.Registracija.Find(id);
            registrationView.KviestaGreitoji = registration.KviestaGreitoji;
            registrationView.VisitoData = registration.VisitoData;
            registrationView.FkDaktarasId = registration.FkDaktarasId;
            registrationView.FkPacientas = registration.FkPacientas;
            registrationView.Busena = registration.Busena;
            registrationView.PateikimoData = registration.PateikimoData;
            return View(registrationView);
        }

        // POST: RegistrationSubsystem/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RegistrationView registrationView)
        {
            try
            {
                var tvarkarastis = db.UzimtumoTvarkarastis.ToList();
                Registracija registracija = new Registracija();
                var checkboxChecked = Request.Form["check"];
                if (checkboxChecked == null)
                {
                    checkboxChecked = "0";
                }
                foreach (var item in tvarkarastis)
                {
                    if (registracija.FkDaktarasId == item.FkDaktarasId && item.TrukmeMin >= 540)
                    {
                        ModelState.AddModelError("", "Laikas negalimas");
                    }
                }
                registracija.VisitoData = registrationView.VisitoData;
                registracija.FkDaktarasId = registrationView.FkDaktarasId;
                registracija.FkPacientasId = Convert.ToInt32(Session["id"]);
                registracija.KviestaGreitoji = Convert.ToSByte(checkboxChecked);
                registracija.Busena = 1;
                registracija.PateikimoData = DateTime.Now;
                db.Registracija.Update(registracija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistrationSubsystem/Delete/5
        public ActionResult Delete(int id)
        {
            RegistrationView registrationView = new RegistrationView();          
            PopulateSelections(registrationView);
            Registracija registracija = db.Registracija.Find(id);
            registrationView.Busena = registracija.Busena;
            registrationView.FkDaktarasId = registracija.FkDaktarasId;
            registrationView.KviestaGreitoji = registracija.KviestaGreitoji;
            registrationView.FkPacientasId = registracija.FkPacientasId;
            registrationView.PateikimoData = registracija.PateikimoData;
            registrationView.VisitoData = registracija.VisitoData;
            return View(registrationView);
        }

        // POST: RegistrationSubsystem/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RegistrationView registrationview)
        {
            try
            {
                // TODO: Add delete logic here
                db.Registracija.Remove(db.Registracija.Find(id));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void PopulateSelections(RegistrationView registrationview)
        {
            var daktarai = db.Daktaras.ToList();
            var vartotojas = db.Vartotojas.ToList();
            List<SelectListItem> selectListdaktaras = new List<SelectListItem>();
            foreach (var item in daktarai)
            {
                foreach (var item1 in vartotojas)
                {
                    if (item.DaktarasId == item1.VartotojasId)
                    {
                        selectListdaktaras.Add(new SelectListItem() { Value = Convert.ToString(item.DaktarasId), Text = item1.Vardas + " " + item1.Pavarde});
                    }               
                }       
            }
            registrationview.DaktarasList = selectListdaktaras;
        }
    }
}
