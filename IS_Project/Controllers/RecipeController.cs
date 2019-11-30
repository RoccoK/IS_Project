using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS_Project.Models;
using IS_Project.ViewModels;

namespace IS_Project.Controllers
{
    public class RecipeController : Controller
    {
        hospitaldbContext ctx = new hospitaldbContext();
        // GET: Recepy
        public ActionResult Index()
        {
            Receptas[] a = ctx.Receptas.ToArray();
            List<Receptas> fit = new List<Receptas>();
            for (int i = 0; i < ctx.Receptas.Count(); i++)
            {
                a[i].FkPacientas = ctx.Pacientas.Find(a[i].FkPacientasId);
                a[i].FkPacientas.PacientasNavigation = ctx.Vartotojas.Find(a[i].FkPacientas.PacientasId);
                a[i].FkVaistas = ctx.Vaistas.Find(a[i].FkVaistasId);
                fit.Add(a[i]);
            }
            List<Receptas> aaa = ctx.Receptas.ToList();
            return View(fit);
        }

        // GET: Recepy/Details/5
        public ActionResult Details(int id)
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
            return View();
        }

        // POST: Recepy/Edit/5
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

        // GET: Recepy/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Recepy/Delete/5
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
