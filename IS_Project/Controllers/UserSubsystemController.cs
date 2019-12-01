using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS_Project.Controllers
{
    public class UserSubsystemController : Controller
    {
        // GET: UserSubsystem
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddUser()
        {
            return View();
        }
        public ActionResult DeleteUser()
        {
            return View();
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
            return View();
        }
    }
}