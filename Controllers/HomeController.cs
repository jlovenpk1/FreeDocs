using FreeDocs.Models;
using FreeDocs.Models.Additional;
using FreeDocs.Models.EFConfigs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace FreeDocs.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        public ActionResult Index()
        {
            db = new ApplicationContext();
            List<Documents> _documents = db.Documents.ToList();
            ViewBag.document = _documents;
            #region ForTest
            //string path1 = "~/Documents/_act";
            //string path2 = "~/Documents/_agreement";
            //string path3 = "~/Documents/_blank";
            //string path4 = "~/Documents/_reference";
            //db.Documents.Add(new Documents() { Name = "act_test.doc", Description = "Тестовый акт", Date = DateTime.Now, Path = path1, Type = TypeDocs._act });
            //db.Documents.Add(new Documents() { Name = "agreement_test.doc", Description = "Тестовый договор", Date = DateTime.Now, Path = path2, Type = TypeDocs._agreement });
            //db.Documents.Add(new Documents() { Name = "blank_test.doc", Description = "Тестовый бланк", Date = DateTime.Now, Path = path3, Type = TypeDocs._blank });
            //db.Documents.Add(new Documents() { Name = "reference_test.doc", Description = "Тестовая справка", Date = DateTime.Now, Path = path4, Type = TypeDocs._reference });
            #endregion
            return View(_documents);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}