using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult TextFiles()
        {
            ViewBag.Message = "TextFiles";
            string[] files = Directory.GetFiles(Server.MapPath("~/TextFiles"));
            FileList Files = new FileList();

            foreach (var file in files)
            {
                var f = new Model.File {
                    text = file
                };
                Files.Add(f);
            }

            return View(Files);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}