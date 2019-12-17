using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS_Project.Models;

namespace IS_Project.Controllers
{
    public class UserController : Controller
    {      
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            Session["id"] = 0;
            Session["role"] = 0;
            Session["state"] = 0;
            Session["loadmain"] = 1;
            string message = "";
            using(hospitaldbContext db = new hospitaldbContext())
            {
                var temp = db.Vartotojas.Where(x => x.Elpastas == user.epastas).FirstOrDefault();
                if(temp != null)
                {
                    if (db.Administratorius.Find(temp.VartotojasId) != null)
                    {
                        Session["role"] = 1; //Administratorius

                    }
                    else if (db.Daktaras.Find(temp.VartotojasId) != null)
                    {
                        Session["role"] = 2; //Daktaras

                    }
                    else if (db.Pacientas.Find(temp.VartotojasId) != null)
                    {
                        Session["role"] = 3; //Pacientas

                    }
                    Session["id"] = temp.VartotojasId;
                    Session["state"] = 1;
                    return Redirect("~/Home/Index");
                }
                else if(user.epastas != null && user.Password != null)
                {
                    message = "Prisijungimo duomenys neteisingi";
                    ViewBag.Message = message;
                }
            }
            return View();
        }
    }
}