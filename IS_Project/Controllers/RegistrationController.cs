using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace IS_Project.Controllers
{
    public class RegistrationController : Controller
    {
        hospitaldbContext ctx = new hospitaldbContext();

        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CreateRegistration()
        {
            var tmp = new Registracija();
            PopulateSections(tmp);
            return View(tmp);
        }

        [HttpPost]
        public ActionResult CreateRegistration(Registracija reg)
        {
            try
            {
                reg.PateikimoData = DateTime.Now;

                reg.KviestaGreitoji = 0;
                reg.Busena = (int)RegistracijosBusenos.LaukiamaPatvirtinimo;
                reg.FkPacientasId = Convert.ToInt32(Session["id"]);
                ctx.Registracija.Add(reg);
                EmailController.SendMailRegister(reg);
                // TODO: Add update logic here

                return RedirectToAction("Index", "Home");
            }
            catch(Exception e)
            {
                var err = e;
                return View(reg);
            }
        }


        public void PopulateSections(Registracija reg)
        {
            var gydytojai = ctx.Daktaras.Include(da => da.DaktarasNavigation).ToList();


            List<SelectListItem> slDocs = new List<SelectListItem>();

            foreach (var item in gydytojai)
                slDocs.Add(new SelectListItem
                {
                    Value = Convert.ToString(item.DaktarasId),
                    Text = item.DaktarasId.ToString()
                        + " - "
                        + item.DaktarasNavigation.Vardas
                        + " "
                        + item.DaktarasNavigation.Pavarde
                        + " "
                        + item.DaktarasNavigation.Pavarde
                        + " "
                        + ((Specializacijos)item.Specializacija).ToString("G")
                }); ;

            reg.ListDoc = slDocs;
        }

        // GET: Registration/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Registration/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Registration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Registration/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
