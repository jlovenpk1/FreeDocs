using FreeDocs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FreeDocs.Controllers._RegLogic;

namespace FreeDocs.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Registration()
        {
            return View(new User());
        }

        public ActionResult RegForm()
        {
            return View();
        }

        public JsonResult LoginCheck(string name) => Json(new Registration().LoginCheck(name), JsonRequestBehavior.AllowGet);
        public JsonResult MailCheck(string mail) => Json(new Registration().MailCheck(mail), JsonRequestBehavior.AllowGet);
    }
}