using IS_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IS_Project.Controllers
{
    public class VisitSubsystemController : Controller
    {
        hospitaldbContext ctx = new hospitaldbContext();


        public ActionResult RoomsIndex()
        {
            var rooms = ctx.Palata.ToList();
            foreach(var room in rooms)
            {
                room.UzimtaVietu = ctx.LigonioVisitas.Where(p => p.FkPalataId == room.PalataId && p.DataIki < DateTime.Now).ToList().Count;
            }
            return View(rooms);

        }

        public ActionResult SearchVisits()
        {
            var id = Request.Form["patient"]  == null ? null : Request.Form["patient"].ToString();


            var visitsIE = ctx.LigonioVisitas
                .Include(visit => visit.FkPalata)
                .Include(visit => visit.FkLiga)
                .Include(visit => visit.FkPacientas)
                    .ThenInclude(pac => pac.PacientasNavigation).ToList();

            int patId = 0;
            if (id != null)
            {
                try
                {
                    patId = Convert.ToInt32(id);
                    visitsIE = visitsIE.Where(s => s.FkPacientasId == patId).ToList();
                }
                catch
                {

                }
            }

            if(visitsIE.Count == 0)
             visitsIE = ctx.LigonioVisitas
                .Include(visit => visit.FkPalata)
                .Include(visit => visit.FkLiga)
                .Include(visit => visit.FkPacientas)
                    .ThenInclude(pac => pac.PacientasNavigation).ToList();

            PopulateSections(visitsIE[0]);
            return View(visitsIE);
        }

        // GET: Visit/Create
        public ActionResult CreateVisit()
        {
            var tmp = new LigonioVisitas();
            PopulateSections(tmp);
            return View(tmp);
        }

        // POST: Visit/Create
        [HttpPost]
        public ActionResult CreateVisit(LigonioVisitas visit)
        {
            try
            {
                // TODO: Add insert logic here
                ctx.Add(visit);
                ctx.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Visit/Edit/5
        public ActionResult EditVisit(int id)
        {
            var visit = ctx.LigonioVisitas.Find(id);
            PopulateSections(visit);
            visit.NamesList[id].Selected = true;
            visit.IllList[id].Selected = true;
            visit.RoomList[id].Selected = true;
            return View(visit);
        }

        // POST: Visit/Edit/5
        [HttpPost]
        public ActionResult EditVisit(int id, LigonioVisitas visit)
        {
            try
            {
                ctx.Update(visit);
                ctx.SaveChanges();
                // TODO: Add update logic here

                return RedirectToAction("SearchVisits", "VisitSubsystem");
            }
            catch
            {
                return View();
            }
        }

        // GET: Visit/Delete/5
        public ActionResult DeleteVisit(int id)
        {
            var visit = ctx.LigonioVisitas.Find(id);
            PopulateSections(visit);
            return View(visit);
        }

        // POST: Visit/Delete/5
        [HttpPost]
        public ActionResult DeleteVisit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ctx.LigonioVisitas.Remove(ctx.LigonioVisitas.Find(id));
                ctx.SaveChanges();
                return RedirectToAction("SearchVisits");
            }
            catch
            {
                return View();
            }
        }

        public void PopulateSections(LigonioVisitas visits)
        {
            var vartotojai = ctx.Pacientas.Include(vart => vart.PacientasNavigation).ToList();
            var rooms = ctx.Palata.ToList();
            var ills = ctx.Liga.ToList();

            List<SelectListItem> selectListVartotojai = new List<SelectListItem>();
            List<SelectListItem> selectListRooms = new List<SelectListItem>();
            List<SelectListItem> selectListIlls = new List<SelectListItem>();

            foreach (var item in vartotojai)
                selectListVartotojai.Add(new SelectListItem
                {
                    Value = Convert.ToString(item.PacientasId),
                    Text = item.PacientasId.ToString()
                        + " - "
                        + item.PacientasNavigation.Vardas
                        + " "
                        + item.PacientasNavigation.Pavarde
                });

            foreach (var item in rooms)
                selectListRooms.Add(new SelectListItem
                {
                    Value = Convert.ToString(item.PalataId),
                    Text = item.PalataNr.ToString()
                });

            foreach (var item in ills)
                selectListIlls.Add(new SelectListItem
                {
                    Value = Convert.ToString(item.LilgaId),
                    Text = item.Pavadinimas.ToString()
                });

            visits.NamesList = selectListVartotojai;
            visits.IllList = selectListIlls;
            visits.RoomList = selectListRooms;
        }
    }
}
